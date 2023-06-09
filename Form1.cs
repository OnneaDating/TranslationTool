namespace OnneaRE;
using Microsoft.CSharp;
using Microsoft.Win32;
using OnneaRE.Models;
using System.CodeDom.Compiler;
using System.Collections;
using System.Data;
using System.Net.Http.Headers;
using System.Resources;
using System.Resources.Tools;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private string _directory = "";
    private bool _generated = false;
    public Form1()
    {
        InitializeComponent();
    }
    private string SelectFolder()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        DialogResult result = folderBrowserDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            string selectedFolderPath = folderBrowserDialog.SelectedPath;
            return selectedFolderPath;
        }
        return "";
    }
    private bool ContainColumn(string columnName, DataTable table)
    {
        DataColumnCollection columns = table.Columns;
        if (columns.Contains(columnName))
        {
            return true;
        }
        return false;
    }
    public int CountCharsUsingLinqCount(string source, char toFind)
    {
        return source.Count(t => t == toFind);
    }
    private async void BtnLoad_Click(object sender, EventArgs e)
    {
        _directory = SelectFolder();
        if (_directory.Length == 0) { return; }
        string[] filePaths = Directory.GetFiles(_directory, "*.resx");

        // Loop through each file path
        var dataTable = new DataTable();
        int i = 0;
   
        bool foundOne = false;
        string mainFile = "";
        foreach (string filePath in filePaths)
        {
            if (CountCharsUsingLinqCount(filePath, '.') == 1)
            {
                if (foundOne)
                {
                    MessageBox.Show($"You should only have one main resource file in folder {_directory}, rest should be translations to various languages");
                }
                foundOne = true;
                mainFile = filePath;
            }
        }
        ParseFile(dataTable, mainFile, true);
        foreach (string filePath in filePaths)
        {
            if (CountCharsUsingLinqCount(filePath, '.') == 1)
                continue;
            ParseFile(dataTable, filePath);
        }
        GrdResource.DataSource = dataTable;

        for (i = 0; i < dataTable.Columns.Count; i++)
        {
            GrdResource.Columns[i].Width = 200;
        }
        foreach (DataGridViewColumn column in GrdResource.Columns)
        {
            if (column.Index != 0)
            {
                ComboboxItem item1 = new ComboboxItem();
                item1.Text = column.Name;
                item1.Value = column.Index;

                cboFromLanguage.Items.Add(item1);

                ComboboxItem item2 = new ComboboxItem();
                item2.Text = column.Name;
                item2.Value = column.Index;

                cboToLanguage.Items.Add(item2);

            }
        }
    }
    private void ParseFile(DataTable dataTable, string filePath, bool main = false)
    {
        DataRow row = null;
        if (!ContainColumn("Key", dataTable))
        {
            dataTable.Columns.Add("Key", typeof(string));
        }
        dataTable.Columns.Add(Path.GetFileName(filePath), typeof(string));
        using (ResXResourceReader reader = new ResXResourceReader(filePath))
        {

            foreach (DictionaryEntry entry in reader)
            {
                if (main)
                {
                    dataTable.Rows.Add(entry.Key.ToString(), entry.Value.ToString());
                }
                else
                {
                    DataRow[] rows = dataTable.Select("Key = '" + entry.Key.ToString() + "'");
                    row = rows[0];
                    row[Path.GetFileName(filePath)] = entry.Value.ToString();
                }
            }
        }
    }
    private async void BtnSave_Click(object sender, EventArgs e)
    {
        _generated = false;
        BtnSave.Enabled = false;
        foreach (DataGridViewColumn col in GrdResource.Columns)
        {
            if (col.Name == "Key") continue;
            string filename = $"{_directory}\\{col.Name}";
            using (ResXResourceWriter writer = new ResXResourceWriter(filename))
            {
                foreach (DataGridViewRow row in GrdResource.Rows)
                {
                    if (row.Cells["Key"].Value != null)
                    {
                        string key = row.Cells["Key"].Value.ToString();
                        string value = row.Cells[col.Name].Value.ToString();
                        writer.AddResource(key, value);
                    }
                }
                writer.Generate();
            }
            if (!_generated)
            {
                Compile($"{_directory}\\{txtCodeFile.Text}", filename);
            }
        }
        BtnSave.Enabled = true;
    }
    private void GrdResource_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        string name = "";
        if (e.ColumnIndex > 0 && e.RowIndex == -1)
        {
            if (imageList.Images.Count < e.ColumnIndex)
            {
                name = GrdResource.Columns[imageList.Images.Count].Name;
            }
            else
            {
                name = GrdResource.Columns[e.ColumnIndex].Name;
            }
            e.PaintBackground(e.ClipBounds, false);
            Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
            int offset = (e.CellBounds.Width - this.imageList.Images[name].Width) / 2;
            pt.X += offset;
            pt.Y += 1;
            this.imageList.Draw(e.Graphics, pt, imageList.Images.IndexOfKey(name));
            e.Handled = true;
        }
    }
    private void Compile(string filename, string resx)
    {
        StreamWriter sw = new StreamWriter(filename);
        string[] errors = null;
        string file = Path.GetFileNameWithoutExtension(resx);
        int index = file.LastIndexOf(".");
        if (index >= 0)
            file = file.Substring(0, index); // or index + 1 to keep slash

        CSharpCodeProvider provider = new CSharpCodeProvider();
        var code = StronglyTypedResourceBuilder.Create(resx, file, txtNameSpace.Text, provider, false, out errors);
        if (errors.Length > 0)
            foreach (var error in errors)
                Console.WriteLine(error);

        provider.GenerateCodeFromCompileUnit(code, sw, new CodeGeneratorOptions());
        sw.Close();
        _generated = true;
    }
    private void GrdResource_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
        if (e.StateChanged != DataGridViewElementStates.Selected) return;
    }
    private void GrdResource_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex != -1)
        {
            GrdResource.ClearSelection();
            GrdResource.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }
    }
    private async Task<IList<Translation>> TranslateText(string text)
    {
        IList<Translation> result = new List<Translation>();
        ChatGPT model = new ChatGPT();
        try
        {

            string url = "https://api.openai.com/v1/engines/text-davinci-003/completions";
            string payload = $@"
        {{
            ""prompt"": ""{text}"",
            ""max_tokens"": 1000,
            ""temperature"": 0.7,
            ""top_p"": 1,
            ""n"": 1,
            ""stop"": null
        }}";
            var apiKey = txtAPIKey.Text;
            string responseContent = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(url, new StringContent(payload, Encoding.UTF8, "application/json"));

                responseContent = await response.Content.ReadAsStringAsync();
                model =  JsonSerializer.Deserialize<ChatGPT>(responseContent);
  
                if (model.usage.total_tokens >= 1000)
                {
                    MessageBox.Show("Errror", $"too many tokens {model.usage.total_tokens}");
                }
                if (model != null)
                {
                    if (model.choices.Count > 0)
                    {
                        string resstring = "";
                        foreach (var val in model.choices)
                        {
                            resstring += val.text;
                        }
                        result =  JsonSerializer.Deserialize<IList<Translation>>(resstring);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return new List<Translation>();
        }
        return result;
    }

    private async void button1_Click(object sender, EventArgs e)
    {
    }
    public async Task<IList<Translation>> DoWork(CancellationToken token, string question)
    {
        await Task.Delay(500, token);
        return await TranslateText(question);
    }

    private async void BtnTranslate_Click(object sender, EventArgs e)
    {
        RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"Software\TranslationTool", true);

        if(myKey == null) {
            myKey = Registry.CurrentUser.CreateSubKey(@"Software\TranslationTool", true);
        }

        if (myKey != null)
        {
            myKey.SetValue("APIKey",txtAPIKey.Text);
        }
        BtnTranslate.Enabled = false;
        cboFromLanguage.Enabled = false;
        cboToLanguage.Enabled = false;

        ComboboxItem selectedFromLanguage = (ComboboxItem)cboFromLanguage.SelectedItem;
        ComboboxItem selectedToLanguage = (ComboboxItem)cboToLanguage.SelectedItem;

        foreach (DataGridViewRow row in GrdResource.Rows)
        {
            object cellToValue = row.Cells[selectedToLanguage.Value].Value;

            if (cellToValue == null)
            {
                continue;
            }
            if (!cellToValue.Equals(""))
            {
                continue;
            }
            await LoopThroughGrid(selectedToLanguage.Value, selectedFromLanguage.Value);
        }

        BtnTranslate.Enabled = true;
        cboFromLanguage.Enabled = true;
        cboToLanguage.Enabled = true;
    }
    private async Task LoopThroughGrid(int columnIndex, int iMainLanguage)
    {
        string columnName;
        string fromLanguage = "";
        string toLanguage = "";
        string question;
        DataGridViewColumn masterColumn;

        masterColumn = GrdResource.Columns[iMainLanguage];

        if (GrdResource.SelectedCells.Count > 0)
        {
            columnName = GrdResource.Columns[columnIndex].Name;
            toLanguage = Helpers.Utils.GetLanguage(columnName);
            fromLanguage = Helpers.Utils.GetLanguage(masterColumn.Name);
        }

        int iRows = 0;
        question = $"Please translate following phrase from {fromLanguage} into {toLanguage} and create  only a trimmed without line breaks a json array  of the phrases as an answer including the columns Id, original and translated<br>";
        foreach (DataGridViewRow row in GrdResource.Rows)
        {

            object cellToValue = row.Cells[columnIndex].Value;
            object cellFromValue = row.Cells[iMainLanguage].Value;

            if (cellToValue == null || !cellToValue.Equals(""))
            {
                continue;
            }
            if (iRows == 10)
            {
                break;
            }
            iRows++;
            question += $"Id {row.Index} {cellFromValue}<br>";

        }
        var res = await DoWork(new CancellationToken(), question);
        foreach (var val in res)
        {
            GrdResource.Rows[val.Id].Cells[columnIndex].Value = val.Translated;
        }
    }

    private void cboToLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboboxItem selectedToLanguage = (ComboboxItem)cboToLanguage.SelectedItem;
        if (selectedToLanguage != null)
        {
            GrdResource.CurrentCell = GrdResource.Rows[0].Cells[selectedToLanguage.Value];
            GrdResource.Columns[selectedToLanguage.Value].Selected = true;
        }
        if (cboToLanguage.Text.Length>0 && cboFromLanguage.Text.Length> 0)
        {
            BtnTranslate.Enabled = true;
        }
        
    }

    private void cboFromLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboboxItem selectedFromLanguage = (ComboboxItem)cboFromLanguage.SelectedItem;
        if (selectedFromLanguage != null)
        {
            GrdResource.CurrentCell = GrdResource.Rows[0].Cells[selectedFromLanguage.Value];
            GrdResource.Columns[selectedFromLanguage.Value].Selected = true;
        }
        if (cboToLanguage.Text.Length > 0 && cboFromLanguage.Text.Length > 0)
        {
            BtnTranslate.Enabled = true;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        BtnTranslate.Enabled = false;
        RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"Software\TranslationTool", false);  
        if (myKey != null)
        {
            string value = (String)myKey.GetValue("APIKey");
            if (value != null)
            {
                txtAPIKey.Text = value.ToString();
            }
        }
    }
}