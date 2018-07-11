#define CHARS16WEB
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

#if CHARS9SIMPLE
			textBox1.Text = "9";
			comboBox1.SelectedIndex = 0;
			enterSpecialCharsForSelectedType();
#elif CHARS16WEB
			textBox1.Text = "16";
			comboBox1.SelectedIndex = 2;
			enterSpecialCharsForSelectedType();
#endif

			//genForFile();
		}

		protected string specialCharsForType(string type)
		{
			switch (comboBox1.Text)
			{
				case "Simple":
					return "";

				case "Windows":
					return "`~!@#$%^&*()_+-={}|[]\\:\";'<>?,./";

/*
TODO: Windows 2008 R2 Server does not like one of the following characters
>'`]):{
*/

				case "Web":
					return "~$";

				case "Numbers":
					return "0-9";
			}

			return "";
		}

		protected void enterSpecialCharsForType(string type)
		{
			textBox2.Text = specialCharsForType(type);
		}

		protected void enterSpecialCharsForSelectedType()
		{
			enterSpecialCharsForType(comboBox1.Text);
		}

		protected void comboBox1_SelectedIndexChanged(object sender, EventArgs ev)
		{
			enterSpecialCharsForType(comboBox1.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int length = int.Parse(textBox1.Text);
			string specials = textBox2.Text;

			var gen = new RandomPassword(specials);
			string password = gen.Generate(length);

			textBox3.Text = password;
		}


		protected void genForFile()
		{
			string appRoot = (new DirectoryInfo(Environment.CurrentDirectory)).Parent.Parent.FullName + @"\";
			var gen = new GenerateForFile(appRoot + @"Data\Emails.txt");
			gen.Generate();
		}
	}
}
