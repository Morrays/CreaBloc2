using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CreaBloc2
{
	public partial class Form1 : Form
	{
		public string language = Properties.Settings.Default.langue;   //Public String language to read the saved language settings
		public Form1()
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language); //Launch the Form with the default/selected language
			InitializeComponent();
		}
		
		public int i = 0;

		//--------FormLoad--------//
		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'dBBlocsDataSet2.Composants' table. You can move, or remove it, as needed.
			this.composantsTableAdapter1.Fill(this.dBBlocsDataSet2.Composants);


			//Crée un fichier txt
			Directory.CreateDirectory(@"C:\Users\beaudonnelk\Documents\TempBloc\blocSelected");
			

			//Emplacement du fichier temporaire
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string dossier = "TempBloc";
			string fullPath = path + @"\" + dossier;
			string nomFichier = fullPath + @"\newBloc.xrb";



			//Ecrit dans le fichier les lignes qui ne changent pas dans tous les blocs
			try
			{
				if (File.Exists(nomFichier))
				{
					File.Delete(nomFichier);
				}

				using (FileStream fs = File.Create(nomFichier))
				{

				}


				using (StreamWriter sw = new StreamWriter(nomFichier, true, System.Text.Encoding.GetEncoding(1252)))
				{
					sw.WriteLine("<< Schéma WinRelais [Bloc] >>");
					sw.WriteLine("¤#Version");
					sw.WriteLine("2·2·");
					sw.WriteLine("EYNARD Pascal·Ingerea·");
					sw.WriteLine("Version 2.2a Premium·");
					sw.WriteLine("¤#PMilieu¤");
					sw.WriteLine("4400·10000");
					sw.WriteLine("¤#NombreSymbole¤");

				}




            }
			catch
			{
				MessageBox.Show("Erreur dans la création du fichier");
			}



		}

		//-----------------------//

		//--------Bouton--------//

		//Trigger Boutton Insertion de ligne dans le dataGridView
		private void button1_Click(object sender, EventArgs e)
		{
			DataBloc.Rows.Add();
		}

		//Trigger Boutton Supprimer Ligne dans le dataGridView
		private void button2_Click_1(object sender, EventArgs e)
		{

			if (DataBloc.SelectedRows.Count > 0)
			{

				DataGridViewSelectedRowCollection row = DataBloc.SelectedRows;

				DataBloc.Rows.RemoveAt(DataBloc.SelectedRows[0].Index);
			}
			else
			{
				MessageBox.Show("Veuillez selectionner une ligne", "Erreur", MessageBoxButtons.OK);
			}
		}

		//Trigger Button pour quitter
		private void button5_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Voulez-vous vraiment quitter", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ @"\TempBloc";
				File.Delete(path + @"\newBloc.xrb");
				Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TempBloc", "tempSelectedBloc.xrb"));
				Application.Exit();
			}
		}

		//Trigger boutton Annuler
		private void button4_Click(object sender, EventArgs e)
		{
			DataBloc.Rows.Clear();
		}

		//Trigger Boutton Ouvrir Fichier
		private void button6_Click(object sender, EventArgs e)
		{
			int size = -1;
			DialogResult result = openFileDialog1.ShowDialog(); // Ouvre la selection de fichier
			if (result == DialogResult.OK)
			{
				string file = openFileDialog1.FileName;
				try
				{
					string text = File.ReadAllText(file);
					size = text.Length;
				}
				catch (IOException)
				{
				}
			}
			Console.WriteLine(size); //Affiche la taille du fichier en mode debug (console)
			Console.WriteLine(result);
		}

		//-----------------------------//

		//--------Datagridview--------//

		// Affiche la position de chaque rangée dans le datagridview a chaque ajout de rangée
		private void DataBloc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{

			i = 0;
			while (i < DataBloc.Rows.Count)
			{
				DataBloc.Rows[i].Cells[0].Value = i + 1;
				i++;
			}
		}

		//Affiche la position de chaque rangée dans le datagridview a chaque suppression de rangée
		private void DataBloc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			i = 0;
			while (i < DataBloc.Rows.Count)
			{
				DataBloc.Rows[i].Cells[0].Value = i + 1;
				i++;

			}

		}

		//------------------------------//


		//--------AJOUT DE BLOC--------//

		//Enregistrement du bloc 
		private void button3_Click(object sender, EventArgs e)
		{

			if (MessageBox.Show("Voulez-vous vraiment sauvegarder", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				//string dans le textbox pour le nom(référence) du bloc
				string nomReference = textBox1.Text;

				//Emplacement fichier temporaire
				string path = @"C:\Users\beaudonnelk\Documents\TempBloc\newBloc.xrb";

				//Emplacement fichier sauvegarder 
				string newPath = @"S:\BE\ELECTRONIQUE\6-Outils\GenS4\Blocs\BlocsBornesAuto\";

				//Emplacemenf fichier composant TEST
				string composant = @"C:\Users\beaudonnelk\Documents\Test winrelais\";

				for (int i =0; i< DataBloc.Rows.Count;i++)
				{
					var valeur = DataBloc.Rows[i].Cells[1].Value;

					int nbrRows = DataBloc.Rows.Count; 
					string composantSelect = composant + valeur + ".xrb";
					var RepereValue = DataBloc.Rows[i].Cells[2].Value;
					string unRepere ="" + RepereValue;
					
					if (i == 0)
					{
						ElemBlocs.addFirstBloc(path, composantSelect, nbrRows, unRepere);

					}
					else
					{
						ElemBlocs.addBlock(path, composantSelect, unRepere, i);
					}
				}

				string finalPath = newPath + nomReference + ".xrb";

				//copie le fichier temp dans le bon dossier		

				if (File.Exists(finalPath))
				{
					MessageBox.Show("Le Bloc existe déjà","Erreur");
				}
				else
				{
				File.Copy(path, finalPath);
				}

				

			}
		}

		//----------------------------//


		//--------MULTILANGUE--------//

		//Fonction appelé pour changer la langue
		private void ChangeLangue(string lang) 
		{
			foreach (Control c in this.Controls)
			{
				ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
				resources.ApplyResources(c, c.Name, new CultureInfo(lang));
			}
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to change the language to english ?\r\n \r\nVoulez-vous changer la langue en anglais ?", " Creabloc2 ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				if (MessageBox.Show("Restart required \r\n \r\nRedémarrage requis", " Creabloc2 ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				{
					//Change la langue en anglais (USA)
					language = "en-US";
					englishToolStripMenuItem.Checked = true;
					françaisToolStripMenuItem.Checked = false;



					//Sauvegarde le choix de l'utilisateur dans les paramètres
					Properties.Settings.Default.langue = "en-US";
					Properties.Settings.Default.Save();

					//Redémarage de l'application 
					Application.Restart();
				}
			}
		}

		private void françaisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to change the language to french ?\r\n \r\nVoulez-vous changer la langue en français ?", " Creabloc2 ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				if (MessageBox.Show("Restart required \r\n \r\nRedémarrage requis", " Creabloc2 ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				{
				//Change la langue en français
				language = "en-US";
				englishToolStripMenuItem.Checked = false;
				françaisToolStripMenuItem.Checked = true;

				Properties.Settings.Default.langue = "fr-FR";
				Properties.Settings.Default.Save();

				Application.Restart();
				}
			}
		}

	}

	//------------------------------//

}

