﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace CreaBloc2
{
	
	public partial class Form1 : Form
	{
		/// <summary>
		/// string public pour lire la langue sauvegarder en paramètre 
		/// </summary>
		public string language = Properties.Settings.Default.langue;

		/// <summary>
		/// Formulaire Princial
		/// </summary>
		public Form1()
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language); //Launch the Form with the default/selected language
			InitializeComponent();
		}

		

		
		/// <summary>
		/// Action effectué au chargement du formulaire
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			string requete = "select Désignation from TypeBloc order by Désignation";
			string[] resType = ElemBlocs.requeteSelect(requete);
			foreach (string type in resType)
			{
				cbType.Items.Add(type);
			}
			
			string requete2 = "select DescBloc from GroupesBornes order by DescBloc";
			string[] resGrp = ElemBlocs.requeteSelect(requete2);

			foreach (string grp in resGrp)
			{
				cbGroupe.Items.Add(grp);
			}

			string requete3 = "select Description from TypeCoffret order by Description";
			string[] resCof = ElemBlocs.requeteSelect(requete3);
			foreach (string coffret in resCof)
			{
				cbCoffret.Items.Add(coffret);
			}

			//Crée le dossier temporaire 
			Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TempBloc\blocSelected");


			//Emplacement du fichier temporaire
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string dossier = "TempBloc";
			string fullPath = path + @"\" + dossier;
			string nomFichier = fullPath + @"\newBloc.xrb";

			

			//Ecrit dans le fichier les lignes qui ne changent pas dans tous les blocs
			try
			{
				ElemBlocs.addTexteNoChangement(nomFichier);

			}
			catch
			{
				MessageBox.Show("Erreur dans la création du fichier");
			}
		}


		/// <summary>
		/// Trigger Boutton Insertion de ligne dans le dataGridView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			//si il y a au moins une ligne et une ligne est selectionné => ajoute au dessus de la ligne selectionné
			if ((DataBloc.Rows.Count > 0) && (DataBloc.SelectedRows.Count > 0))
			{
				DataBloc.Rows.Insert(DataBloc.SelectedRows[0].Index);

			}
			// si 0 ligne existante ou pas de ligne selectionné => ajoute a la fin 
			else
			{
				DataBloc.Rows.Add();
			}
			
		}

		/// <summary>
		/// Trigger Boutton Supprimer Ligne
		/// Supprime une ligne selectionné dans le datagridview
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Trigger Button pour quitter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Voulez-vous vraiment quitter", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TempBloc";

				//suppresion dossier et fichier temporaire
				File.Delete(path + @"\newBloc.xrb");
				Directory.Delete(path + @"\blocSelected", true);
				Application.Exit();
			}
		}

		/// <summary>
		/// Trigger boutton Annuler
		/// Suppression de toutes les lignes, liste déroulantes 
		/// et textbox du formulaire 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			// réinitialisation des champs
			cbType.Text = null;
			cbGroupe.Text = null;
			cbCoffret.Text = null;
			textBox2.Text = null;
			textBox3.Text = null;
			DataBloc.Rows.Clear();
		}

		/// <summary>
		/// Trigger Boutton Ouvrir Fichier
		/// Ouvre un pop-up de selection de fichier
		/// afin de chargé un bloc deja enregistrer 
		/// et de pouvoir le modifier
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button6_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog(); // Ouvre la selection de fichier
			if (result == DialogResult.OK)
			{

				//récupère le chemin du fichier selectionné
				string file = openFileDialog1.FileName;
				string[] file1 = file.Split('\\');
				file = file1[7].ToString();
				file = file.Replace(".xrb", "");
				DataBloc.Rows.Clear();

				//Remplissage des champs
				//Recupère la valeur de DescBloc en fonction bloc choisi
				string query = "select DescBloc From GroupesBornes, Generalites where Generalites.GroupeBorne = GroupesBornes.BlocBorne and Generalites.Clé ='" + file + "';";
				string[] grpBorne = ElemBlocs.requeteSelect(query);
				//Change le texte du combobox
				cbGroupe.Text = grpBorne[0].ToString();

				//Recupère la valeur de DescBloc en fonction du bloc choisi
				string query2 = "Select Coffret from Generalites where Clé='" + file + "';";
				string[] coffret = ElemBlocs.requeteSelect(query2);
				cbCoffret.Text = coffret[0].ToString();

				//Recupère la valeur de description en fonction du bloc choisi
				string query3 = "Select description from Generalites where Clé ='" + file + "';";
				string[] desc = ElemBlocs.requeteSelect(query3);
				textBox2.Text = desc[0].ToString();

				//Recupère la valeur de commentaire en fonction du bloc choisi 
				string query4 = "Select commentaire from Generalites where Clé ='" + file + "';";
				string[] com = ElemBlocs.requeteSelect(query4);
				textBox3.Text = com[0].ToString();


				string type = file.Substring(2, 3);
				string query5 = "select Désignation From TypeBloc where BlocType ='" + type + "';";
				string[] typeA = ElemBlocs.requeteSelect(query5);
				cbType.Text = typeA[0].ToString();


				string requete = "select * from elemBloc where refBloc ='" + file + "'";

				DataTable resultdt = ElemBlocs.requeteSelectMult(requete);
				List<string> rows = new List<string>();

				foreach (DataRow dataRow in resultdt.Rows)
				{
					rows.Add(string.Join(";", dataRow.ItemArray.Select(item => item.ToString())));
				}
				string[] resultat = rows.ToArray();


				//Remplisage des ligne dans le datagridview
				int compteur = 0;
				foreach (string s in resultat)
				{
					DataBloc.Rows.Add();
					string res = resultat[compteur];
					DataBloc.Rows[compteur].Cells[1].Value = resultat[compteur].Split(';')[1];
					DataBloc.Rows[compteur].Cells[2].Value = resultat[compteur].Split(';')[3];


					compteur++;
				}
			}
		}
	

		/// <summary>
		/// Action effectué quand une ligne est ajoutée
		/// Permet de chargé la liste des blocs unitaire
		/// avec prise en compte de l'obsolescence
		/// et affichage de la position automatiquement
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataBloc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			//Remplissage comboBox avec prise en compte de l'obsolescence
			string requete = "select Réferences from Composants where obsolescence = false order by Réferences";

			string[] fin = ElemBlocs.requeteSelect(requete);



			BindingList<string> list = new BindingList<string>();

			//ajout de chaque string dans le string array a la bindingList
			foreach (string s in fin)
			{
				list.Add(s);
			}

			//Lie la Bindinglist au ComboBox
			DataGridViewComboBoxCell box = DataBloc.Rows[e.RowIndex].Cells[1] as DataGridViewComboBoxCell;
			box.DataSource = list;

			///////////////////////

			//Position automatique
			int i = 0;
			while (i < DataBloc.Rows.Count)
			{
				DataBloc.Rows[i].Cells[0].Value = i + 1;
				i++;
			}
		}

		/// <summary>
		/// Actualise la position de chaque rangée dans 
		/// le datagridview a chaque suppression de ligne
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataBloc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			 int i = 0;
			while (i < DataBloc.Rows.Count)
			{
				DataBloc.Rows[i].Cells[0].Value = i + 1;
				i++;

			}
		}


		/// <summary>
		/// Enregistrement du bloc 
		/// Permet la gération et sauvvegarde
		/// du fichier xrb, fait appèle aux
		/// fonction présente dans Blocs.cs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{

			if (MessageBox.Show("Voulez-vous vraiment sauvegarder", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				int ok = 0;

				//Emplacement fichier temporaire
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TempBloc\newBloc.xrb";

				//Emplacement fichier sauvegarder 
				string newPath = Properties.Settings.Default.blocFinale.ToString();

				//Emplacemenf fichier composant 
				string composant = Properties.Settings.Default.blocUnitaire.ToString();



				string requeteType = "select BlocType from TypeBloc where Désignation ='" + cbType.Text.ToString() + "'";
				string[] typeA = ElemBlocs.requeteSelect(requeteType);
				string type = ElemBlocs.ConvertStringArrayToString(typeA);

				string requeteGroupe = "select FonctionBloc from GroupesBornes where DescBloc ='" + cbGroupe.Text.ToString() + "'";
				string[] grpA = ElemBlocs.requeteSelect(requeteGroupe);
				string grp = ElemBlocs.ConvertStringArrayToString(grpA);

				int compteurFichier = 0;
				string[] files = Directory.GetFiles(newPath);
				string startW = newPath + @"\EB" + type + grp;
				for (int i = 0; i < files.Length; i++)
				{

					if (files[i].StartsWith(startW))
					{
						compteurFichier++;
					}
				}

				compteurFichier++;
				string nomRef = "EB" + type + grp;
				string nomReference = nomRef + String.Format("{0:0000}", +compteurFichier);
				string descrition = textBox2.Text.ToString();
				string commentaire = textBox3.Text.ToString();

				if (cbType.Text == "" || cbGroupe.Text == "" || cbCoffret.Text == "")
				{
					MessageBox.Show("Une valeur n'est pas choisi");
				}
				else
				{
					foreach (DataGridViewRow row in DataBloc.Rows)
					{
						if (row.Cells[1].Value == null)
						{
							ok++;
						}
					}

					if (ok > 0)
					{
						MessageBox.Show("Une ligne possède un composant vide !", "Erreur");
					}
					else if (ok == 0)
					{
						for (int i = 0; i < DataBloc.Rows.Count; i++)
						{
							var valeur = DataBloc.Rows[i].Cells[1].Value;

							int nbrRows = DataBloc.Rows.Count;
							string composantSelect = composant + @"\" + valeur + ".xrb";
							if (!File.Exists(composantSelect))
							{
								MessageBox.Show("Dossier selectionner ne comporte pas de fichier composant", "Erreur");
							}
							else
							{
								var RepereValue = DataBloc.Rows[i].Cells[2].Value;
								string unRepere = "" + RepereValue;

								if (i == 0)
								{
									ElemBlocs.addFirstBloc(path, composantSelect, nbrRows, unRepere);

								}
								else
								{
									ElemBlocs.addBlock(path, composantSelect, unRepere, i);
								}

							}
						}
						string finalPath = newPath + @"\" + nomReference + ".xrb";

						//copie le fichier temp dans le bon dossier		


						File.Copy(path, finalPath);

						if (MessageBox.Show("Sauvegarde effectuée", "CreaBloc", MessageBoxButtons.OK) == DialogResult.OK)
						{
							foreach (DataGridViewRow row in DataBloc.Rows)
							{
								if (row.Cells[2].Value == null)
								{
									string reqs = "Insert Into elemBloc (refBloc, [position], refComposant, repère) Values ('" + nomReference + "', '" + row.Cells[0].Value.ToString() + "', '" + row.Cells[1].Value.ToString() + "', '')";
									ElemBlocs.requeteInsert(reqs);
								}
								else
								{
									string req = "Insert Into elemBloc (refBloc, [position], refComposant, repère) Values ('" + nomReference + "', '" + row.Cells[0].Value.ToString() + "', '" + row.Cells[1].Value.ToString() + "', '" + row.Cells[2].Value.ToString() + "')";
									ElemBlocs.requeteInsert(req);
								}
							}

							double largeurBloc = ((ElemBlocs.LargeurBloc(finalPath)*3.0)/100.0);





							File.Delete(path);
							ElemBlocs.addTexteNoChangement(path);

							//requete pour avoir BlocBorne 
							string requeteGrpBorne = "select BlocBorne from GroupesBornes where DescBloc ='" + cbGroupe.Text.ToString() + "';";
							string[] grpBorne = ElemBlocs.requeteSelect(requeteGrpBorne);
							string blocBorne = ElemBlocs.ConvertStringArrayToString(grpBorne);

							//requete final
							if (textBox2.Text == null)
							{
								string sqlD = "Insert Into Generalites (Clé, description, commentaire, Largeur, Coffret, GroupeBorne) Values ('" + nomReference + "','', '" + commentaire.Replace("'","''") + "', '" + largeurBloc + "', '" + cbCoffret.Text.ToString() + "', '" + blocBorne + "');";
								ElemBlocs.requeteInsert(sqlD);
							}
							else if (textBox3.Text == null)
							{
								string sqlC = "Insert Into Generalites (Clé, description, commentaire, Largeur, Coffret, GroupeBorne) Values ('" + nomReference + "','" + descrition.Replace("'", "''") + "', '', '" + largeurBloc + "', '" + cbCoffret.Text.ToString() + "', '" + blocBorne + "');";
								ElemBlocs.requeteInsert(sqlC);
							}
							else if (textBox2.Text == null && textBox3.Text == null)
							{
								string sqlDC = "Insert Into Generalites (Clé, description, commentaire, Largeur, Coffret, GroupeBorne) Values ('" + nomReference + "','', '', '" + largeurBloc + "', '" + cbCoffret.Text.ToString() + "', '" + blocBorne + "');";
								ElemBlocs.requeteInsert(sqlDC);
							}
							else
							{
								string sql = "Insert Into Generalites (Clé, description, commentaire, Largeur, Coffret, GroupeBorne) Values ('" + nomReference + "','" + descrition.Replace("'", "''") + "', '" + commentaire.Replace("'", "''") + "', '" + largeurBloc + "', '" + cbCoffret.Text.ToString() + "', '" + blocBorne + "');";
								ElemBlocs.requeteInsert(sql);

							}

							//Réinitialisation
							DataBloc.Rows.Clear();
							cbType.Text = null;
							cbGroupe.Text = null;
							cbCoffret.Text = null;
							textBox2.Text = null;
							textBox3.Text = null;

						}
					}
				}
			}
		}



		/// <summary>
		/// Fonction appelé pour changer la langue
		/// avec sauvegarde dans les paramètres généraux
		/// </summary>
		/// <param name="lang"></param>
		private void ChangeLangue(string lang)
		{
			foreach (Control c in this.Controls)
			{
				ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
				resources.ApplyResources(c, c.Name, new CultureInfo(lang));
			}
		}

		/// <summary>
		/// Fonction appelé selon le choix de la langue
		/// ici l'anglais
		/// REDEMARAGE REQUIS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Fonction appelé selon le choix de la langue
		/// ici le français
		/// REDEMARAGE REQUIS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Changement de l'emplacement des blocs unitaires
		/// Ouvre une pop-up de selection de dossier
		/// et sauvegarde le chemin dans les paramètres de l'application
		/// REDEMARRAGE REQUIS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void blocUnitaireToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ouvre une fenetre de selection de dossier
			using (var fbd = new FolderBrowserDialog())
			{

				fbd.Description = "Choisir le dossier ou se trouve les blocs unitaires: ";
				string dossierChemin = "";
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					if (MessageBox.Show("Redémarrage requis", " Creabloc2 ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						//chemin du dossier selectionner
						dossierChemin = fbd.SelectedPath;

						//change le chemin avec celui selectionné dans les paramètres
						Properties.Settings.Default.blocUnitaire = dossierChemin;

						//Sauvegarde des paramètres
						Properties.Settings.Default.Save();
						Application.Restart();
					}
				}
			}
		}


		/// <summary>
		/// Changement du l'emplacement de sauvegarde des blocs 
		/// Ouvre une pop-up de selection de dossier
		/// et sauvegarde le chemin dans les paramètres de l'application
		/// REDEMARAGE REQUIS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void blocFinalToolStripMenuItem_Click(object sender, EventArgs e)
		{

			using (var fbdF = new FolderBrowserDialog())
			{
				if (Properties.Settings.Default.langue == "fr-FR")
				{
					fbdF.Description = "Choisir le dossier de sauvgarde: ";
					string dossierCheminF = "";
					if (fbdF.ShowDialog() == DialogResult.OK)
					{
						if (MessageBox.Show("Redémarrage requis\r\n \r\nRestart required ", " Creabloc2 ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
						{
							dossierCheminF = fbdF.SelectedPath;
							Properties.Settings.Default.blocFinale = dossierCheminF;
							Properties.Settings.Default.Save();
							Application.Restart();
						}
					}
				}
			}
		}
	}
}

	



