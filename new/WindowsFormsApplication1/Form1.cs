using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public class Form1 : Form
	{
		public string path;

		private IContainer components = null;

		private ContextMenuStrip contextMenuStrip1;

		private OpenFileDialog openFileDialog1;

		private TextBox textBox1;

		private Button openFileButton;
        private Label label1;

		private Button processButton;

		public Form1()
		{
			this.InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void openFileButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ShowDialog();
			this.path = ofd.FileName;
			this.textBox1.Text = this.path;
		}

		private void processButton_Click(object sender, EventArgs e)
		{
            if ( this.path == null )
            {
                MessageBox.Show("对不起，请先选择要处理的文件！");
                 return ;
            }
			string strReadFilePath = this.path;
			StreamReader readFile = new StreamReader(strReadFilePath);
			string resultPath = Path.GetDirectoryName(strReadFilePath) + "\\Result1.txt";
			FileStream fs = new FileStream(resultPath, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);
			int line = 1;
			while (!readFile.EndOfStream)
			{
				string readLine = readFile.ReadLine();
				string newline = readLine.Replace("D", "");
				string newline2 = newline.Replace(",", string.Empty);
				string newline3 = newline2.Replace(" ", string.Empty);
				sw.Write("第" + line + "行的统计结果\r\n");
				line++;
				sw.Write("ABC = " + Form1.SubstringCount(newline3, "ABC") + "\r\n");
               int abc = Form1.SubstringCount(newline3, "ABC");
				sw.Write("ACB = " + Form1.SubstringCount(newline3, "ACB") + "\r\n");
                int acb = Form1.SubstringCount(newline3, "ACB");
				sw.Write("BAC = " + Form1.SubstringCount(newline3, "BAC") + "\r\n");
                int bac = Form1.SubstringCount(newline3, "BAC");
				sw.Write("BCA = " + Form1.SubstringCount(newline3, "BCA") + "\r\n");
                int bca = Form1.SubstringCount(newline3, "BCA");
				sw.Write("CAB = " + Form1.SubstringCount(newline3, "CAB") + "\r\n");
                int cab = Form1.SubstringCount(newline3, "CAB");
				sw.Write("CBA = " + Form1.SubstringCount(newline3, "CBA") + "\r\n");
                int cba = Form1.SubstringCount(newline3, "CBA");

                sw.Write("ALL = " + (Form1.SubstringCount(newline3, "ABC") + Form1.SubstringCount(newline3, "ACB") +
                    Form1.SubstringCount(newline3, "BAC")+Form1.SubstringCount(newline3, "BCA")+
                    Form1.SubstringCount(newline3, "CAB") + Form1.SubstringCount(newline3, "CBA")) + "\r\n");
				sw.Flush();
			}
			readFile.Close();
			fs.Close();
			this.textBox1.Text = "成功, 结果在result.txt";
		}

		public static int SubstringCount(string str, string substring)
		{
			int result;
			if (str.Contains(substring))
			{
				string strReplaced = str.Replace(substring, "");
				result = (str.Length - strReplaced.Length) / substring.Length;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openFileButton.Location = new System.Drawing.Point(77, 149);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(124, 45);
            this.openFileButton.TabIndex = 5;
            this.openFileButton.Text = "1 打开文件";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // processButton
            // 
            this.processButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.processButton.Location = new System.Drawing.Point(222, 149);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(95, 45);
            this.processButton.TabIndex = 6;
            this.processButton.Text = "2 处理";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 64);
            this.label1.TabIndex = 7;
            this.label1.Text = "欢迎来到Y迷宫数据处理软件，共两步。\r\n\r\n1、选择要计数的文件\r\n2、处理";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(381, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Y迷宫数据处理软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }
	}
}
