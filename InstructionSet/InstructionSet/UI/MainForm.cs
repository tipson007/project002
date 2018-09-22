using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstructionSet.Models;
using InstructionSet.Models.Decorators;

namespace InstructionSet.UI
{
    public partial class MainForm : Form
    {
        private bool isCurrentGuideDirty;
        private string currentGuideFilePath, currentGuideName;
        private InstructionGuide currentGuide;
        private Control currentTextBlockRef;

        public MainForm()
        {
            InitializeComponent();
            UpdateMenuAndPanelVisibility();
        }

        private void UpdateMenuAndPanelVisibility()
        {
            var hasGuide = currentGuide != null;
            saveAsToolStripMenuItem.Enabled = hasGuide;
            guideToolStripMenuItem.Enabled = hasGuide;
            saveToolStripMenuItem.Enabled = hasGuide;
            rtbGuideText.Enabled = hasGuide;
            splitContainer1.Panel1Collapsed = !hasGuide;
        }

        private void UpdateTitle()
        {
            if (!string.IsNullOrEmpty(currentGuideFilePath))
            {
                currentGuideName = Path.GetFileName(currentGuideFilePath);
                Text = currentGuideName;
            }
            else
            {
                currentGuideName = "Untitled";
                Text = "Untitled - Instruction Set";
            }
        }

        private void UpdateUIView()
        {
            UpdateListOfTextBlocksPanel();
            rtbGuideText.Rtf = currentGuide.ToRtf();
        }

        private void UpdateListOfTextBlocksPanel()
        {
            flpGuideTableOfContent.SuspendLayout();
            flpGuideTableOfContent.Controls.Clear();
            var index = 0;
            foreach (var textblock in currentGuide)
            {
                var plainTextBlock = TextBlockUtil.FindPlainTextBox(textblock);
                var tbr = new Label()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    ContextMenuStrip = cmsForTextBlock,
                    Cursor = Cursors.Hand,
                    Location = new Point(3, 3),
                    Margin = new Padding(3),
                    Padding = new Padding(4, 0, 0, 0),
                    Size = new Size(flpGuideTableOfContent.ClientSize.Width - 6, 23),
                    Dock = (index == 0 ? DockStyle.None : DockStyle.Top),
                    TabIndex = index,
                    Text = plainTextBlock.Text,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = textblock
                };
                tbr.Click += TextBlockRef_Click;
                tbr.MouseDown += TextBlockRef_MouseDown;
                tbr.MouseEnter += TextBlockRef_MouseEnter;
                tbr.MouseLeave += TextBlockRef_MouseLeave;
                index++;
                flpGuideTableOfContent.Controls.Add(tbr);
            }
            flpGuideTableOfContent.ResumeLayout();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isCurrentGuideDirty)
            {
                var result = MessageBox.Show($"Do you want to save changes to {currentGuideName}?", "Instruction Set", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    SaveInstructionGuide();
            }
            currentGuideFilePath = "";
            OpenInstructionGuide();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isCurrentGuideDirty)
            {
                var result = MessageBox.Show($"Do you want to save changes to {currentGuideName}?", "Instruction Set", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    SaveInstructionGuide();
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentGuideFilePath = openFileDialog.FileName;
                OpenInstructionGuide();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentGuideFilePath))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentGuideFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            SaveInstructionGuide();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentGuideFilePath = saveFileDialog.FileName;
                SaveInstructionGuide();
                UpdateTitle();
                isCurrentGuideDirty = false;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var instructionTextBlock = new BoldDecorator(new ListDecorator(new PlainTextBlock()));
            currentGuide.Add(instructionTextBlock);
            EditTextBlock(instructionTextBlock);
            isCurrentGuideDirty = true;
        }

        private void LegalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var legalTextBlock = new IndentDecorator(new ItalicsDecorator(new PlainTextBlock()), IndentDecorator.IndentType.Left);
            currentGuide.Add(legalTextBlock);
            EditTextBlock(legalTextBlock);
            isCurrentGuideDirty = true;
        }

        private void FlpGuideTableOfContent_SizeChanged(object sender, EventArgs e)
        {
            if (flpGuideTableOfContent.Controls.Count > 0)
            {
                var firstControl = flpGuideTableOfContent.Controls[0];
                firstControl.Width = flpGuideTableOfContent.ClientSize.Width - 6;
            }
        }

        private void TextBlockRef_Click(object sender, EventArgs e)
        {
            if (currentTextBlockRef != null)
            {
                currentTextBlockRef.BackColor = Color.White;
                currentTextBlockRef.ForeColor = Color.Black;
            }
            var tbr = sender as Control;
            tbr.BackColor = Color.FromArgb(0, 122, 204);
            tbr.ForeColor = Color.White;
            currentTextBlockRef = tbr;
            EditTextBlock(tbr.Tag as TextBlock);
        }

        private void TextBlockRef_MouseLeave(object sender, EventArgs e)
        {
            var tbr = sender as Control;
            if (currentTextBlockRef != tbr)
            {
                tbr.BackColor = Color.White;
                tbr.ForeColor = Color.Black;
            }
        }

        private void TextBlockRef_MouseEnter(object sender, EventArgs e)
        {
            var tbr = sender as Control;
            if (currentTextBlockRef != tbr)
            {
                tbr.BackColor = Color.FromArgb(201, 222, 245);
                tbr.ForeColor = Color.Black;
            }
        }

        private void TextBlockRef_MouseDown(object sender, MouseEventArgs e)
        {
            var tbr = sender as Control;
            tbr.BackColor = Color.FromArgb(0, 122, 204);
            tbr.ForeColor = Color.White;
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var textBlock = GetTextBlockWithMenuItem(sender);
            EditTextBlock(textBlock);
        }

        private void RemoveTextBlockMenuItem_Click(object sender, EventArgs e)
        {
            var textBlock = GetTextBlockWithMenuItem(sender);
            currentGuide.MoveDown(textBlock);
            UpdateUIView();
            isCurrentGuideDirty = true;
        }

        private void MoveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var textBlock = GetTextBlockWithMenuItem(sender);
            currentGuide.MoveUp(textBlock);
            UpdateUIView();
            isCurrentGuideDirty = true;
        }

        private void MoveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var textBlock = GetTextBlockWithMenuItem(sender);
            currentGuide.MoveDown(textBlock);
            UpdateUIView();
            isCurrentGuideDirty = true;
        }

        private void EditTextBlock(TextBlock textBlock)
        {
            using (var dlg = new EditTextBlockForm(textBlock, Font))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var result = dlg.Result;
                    currentGuide.Replace(textBlock, result);
                    UpdateUIView();
                    isCurrentGuideDirty = true;
                }
            }
            UpdateListOfTextBlocksPanel();
        }

        private void OpenInstructionGuide()
        {
            try
            {
                if (string.IsNullOrEmpty(currentGuideFilePath))
                {
                    currentGuide = new InstructionGuide();
                }
                else
                {
                    currentGuide = InstructionGuideFile.DeserializeFromXmlFile(currentGuideFilePath);
                }
                currentGuide.DefaultFont = Font;
                UpdateMenuAndPanelVisibility();
                UpdateTitle();
                UpdateListOfTextBlocksPanel();
                UpdateUIView();
                isCurrentGuideDirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Instruction Set");
                currentGuide = new InstructionGuide();
            }
        }

        private void SaveInstructionGuide()
        {
            try
            {
                InstructionGuideFile.SerializeToXmlFile(currentGuide, currentGuideFilePath);
                UpdateTitle();
                isCurrentGuideDirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Instruction Set");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isCurrentGuideDirty)
            {
                var result = MessageBox.Show($"Do you want to save changes to {currentGuideName}?", "Instruction Set", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (result == DialogResult.Yes)
                    SaveInstructionGuide();
            }
        }

        private TextBlock GetTextBlockWithMenuItem(object menuItem)
        {
            var cmsMenuItem = menuItem as ToolStripItem;
            if (cmsMenuItem != null)
            {
                var owner = cmsMenuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    return owner.SourceControl.Tag as TextBlock;
                }
            }
            return null;
        }
    }
}
