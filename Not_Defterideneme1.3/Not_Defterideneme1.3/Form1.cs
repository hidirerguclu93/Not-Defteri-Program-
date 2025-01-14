using System.Drawing.Text;

namespace Not_Defterideneme1._3
{
    public partial class Form1 : Form
    {
        private int TabCount = 0; //o anda a�ik olan belgeler
        public Form1()
        {
            InitializeComponent();
        }

        #region Metotlar
        #region Sekmeler

        private void AddTab()  // Sekme ekleme
        {
            RichTextBox Body = new RichTextBox();
            Body.Name = "Body";
            Body.Dock = DockStyle.Fill;
            Body.ContextMenuStrip = contextMenuStrip1;

            TabPage NewPage = new TabPage();
            TabCount += 1;

            string DocumentText = "Belge" + TabCount;
            NewPage.Name = DocumentText;
            NewPage.Text = DocumentText;
            NewPage.Controls.Add(Body);


            tabControl1.TabPages.Add(NewPage);
        }

        private TabControl GetTabControl1()
        {
            return tabControl1;
        }

        private void RemoveTab(TabControl tabControl1) // Sekmeleri Kald�rma
        {
            if (tabControl1.TabPages.Count != 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                AddTab();
            }
        }

        private void RemoveAllTab() // T�m sekmeleri kald�rma
        {
            foreach (TabPage Page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(Page);
            }
            AddTab();
        }

        private void RemoveAllTabsButThis() //A��k olan haricinde sekmeleri kapat�r
        {
            foreach (TabPage Page in tabControl1.TabPages)
            {
                if (Page.Name != tabControl1.SelectedTab.Name)
                {
                    tabControl1.TabPages.Remove(Page);
                }
            }
        }

        #endregion
        #region KaydetA�
        private void Save() // Belgeyi kaydetme i�lemi
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    // Dosya uzant�s�na g�re format belirle
                    var fileType = saveFileDialog1.FileName.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, fileType);
                }
            }
        }

        private void SaveAs() // Belgeyi farkl� isimle kaydet
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save As";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    // Dosya uzant�s�na g�re format belirle
                    var fileType = saveFileDialog1.FileName.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, fileType);
                }
            }
        }
        private void Open() // Belgeyi a�ma i�lemi
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|All Files|*.*";
            openFileDialog1.Title = "Open";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Length > 0)
                {
                    // Dosya uzant�s�na g�re format belirle
                    var fileType = openFileDialog1.FileName.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
                    GetCurrentDocument.LoadFile(openFileDialog1.FileName, fileType);
                }
            }
        }
        #endregion
        #region �zellikler
        private RichTextBox GetCurrentDocument
        {
            get { return (RichTextBox)tabControl1.SelectedTab.Controls["Body"]; }
        }
        #endregion
        #region TextFunctions
        private void Undo()
        {
            GetCurrentDocument.Undo();
        }
        private void Redo()
        {
            GetCurrentDocument.Redo();
        }
        private void Cut()
        {
            GetCurrentDocument.Cut();
        }
        private void Copy()
        {
            GetCurrentDocument.Copy();
        }
        private void Paste()
        {
            GetCurrentDocument.Paste();
        }
        private void SelectAll()
        {
            GetCurrentDocument.SelectAll();
        }
        #endregion
        #region Fontlar
        private void GetFontCollection() //Fontlar�n y�klenmesi
        {
            InstalledFontCollection InsFonts = new InstalledFontCollection();
            foreach (FontFamily item in InsFonts.Families)
            {
                toolStripComboBoxFontType.Items.Add(item.Name);
            }
            toolStripComboBoxFontType.SelectedIndex = 0;
        }
        private void PopulateFontSize() //Font �l�eklerini olu�tur
        {
            for (int i = 0; i <= 75; i++)
            {
                toolStripComboBoxFontSize.Items.Add(i);
            }
            toolStripComboBoxFontSize.SelectedIndex = 12;
        }
        #endregion


        #endregion

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void yineleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void yap��t�rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void t�m�n�Se�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void a�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void farkl�KaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void yeniToolStripButton_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void SilmekToolStripButton1_Click(object sender, EventArgs e)
        {
            RemoveTab(GetTabControl1());
        }

        private void a�ToolStripButton_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void kesToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void kopyalaToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void yap��t�rToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            Font BoldFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Bold);
            Font RegularFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Bold)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = BoldFont;
            }
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            Font ItalicFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Italic);
            Font RegularFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Italic)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = ItalicFont;
            }
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            Font UnderlineFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Underline);
            Font RegularFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Underline)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = UnderlineFont;
            }
        }

        private void toolStripButtonStrikeout_Click(object sender, EventArgs e)
        {
            Font StrikeoutFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Strikeout);
            Font RegularFont = new Font(
                GetCurrentDocument.SelectionFont.FontFamily,
                GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Strikeout)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = StrikeoutFont;
            }
        }

        private void toolStripButtonUpper_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToUpper();
        }

        private void toolStripButtonLower_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToLower();
        }

        private void toolStripButtonIncrease_Click(object sender, EventArgs e)
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints + 2;

            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name,
                NewFontSize, GetCurrentDocument.SelectionFont.Style);

            GetCurrentDocument.SelectionFont = NewSize;
        }

        private void toolStripButtonDecrease_Click(object sender, EventArgs e)
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints - 2;

            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name,
                NewFontSize, GetCurrentDocument.SelectionFont.Style);

            GetCurrentDocument.SelectionFont = NewSize;
        }

        private void toolStripButtonFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetCurrentDocument.SelectionColor = colorDialog1.Color;
            }
        }

        private void toolStripMenuItemGreen_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectionBackColor = Color.Lime;
        }

        private void toolStripMenuItemOrange_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectionBackColor = Color.DarkOrange;
        }

        private void toolStripMenuItemYellow_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectionBackColor = Color.Yellow;
        }

        private void toolStripComboBoxFontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFont = toolStripComboBoxFontType.SelectedItem.ToString();
            float currentFontSize = GetCurrentDocument.SelectionFont.Size;
            Font newFont = new Font(selectedFont, currentFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = newFont;
        }

        private void toolStripComboBoxFontSize_Click(object sender, EventArgs e)
        {
            float newSize;
            if (float.TryParse(toolStripComboBoxFontSize.SelectedItem.ToString(), out newSize))
            {
                Font newFont = new Font(GetCurrentDocument.SelectionFont.Name, newSize, GetCurrentDocument.SelectionFont.Style);
                GetCurrentDocument.SelectionFont = newFont;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            RemoveTab(GetTabControl1());
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            RemoveAllTab();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            RemoveAllTabsButThis();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddTab();
            GetFontCollection();
            PopulateFontSize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetCurrentDocument.Text.Length > 0)
            {
                toolStripStatusLabel1.Text = "Toplam karakter say�s� = " +
                    GetCurrentDocument.Text.Length.ToString();

            }      
        }
    }

}


