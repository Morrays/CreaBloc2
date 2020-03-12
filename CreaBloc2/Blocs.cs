using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace CreaBloc2
{
    //classe des composants du bloc
    class ElemBlocs
    {

        
        /// <summary>
        /// Fonction qui calcule largeur d'un bloc
        /// a partir d'un fichier
        /// </summary>
        /// <param name="chemin">Chemin de l'empalcement du fichier </param>
        /// <returns> Retourne la largeur d'un bloc</returns>
        public static int LargeurBloc(String chemin)
        {
            int largeur = 0;


            using (System.IO.StreamReader sr = new System.IO.StreamReader(chemin, System.Text.Encoding.GetEncoding(1252)))
            {


                string ligne;

                int i = 0;

                try
                {

                    while ((ligne = sr.ReadLine()) != null)
                    {
                        if (ligne.StartsWith(@"¤#Contour¤"))
                        {
                            i = 1;
                        }
                        else if (i == 1)
                        {

                            if (!ligne.StartsWith(@"¤#"))
                            {
                                string[] split = ligne.Split('·');
                                int coordX1 = int.Parse(split[0]);
                                int coordX2 = int.Parse(split[2]);

                                int j = 0;
                                if (coordX1 > coordX2)
                                {
                                    j = coordX1;
                                }
                                else
                                {
                                    j = coordX2;
                                }
                                if (j > largeur)
                                {
                                    largeur = j;
                                }



                            }
                            else { i = 0; }
                        }

                        else { }
                    }

                }
                catch (IOException e1)
                {
                    Console.WriteLine(e1);
                }
                try
                {
                    sr.Close();
                }
                catch (IOException e2)
                {
                    Console.WriteLine(e2);
                }
                if (largeur <= 0)
                {
                    largeur = 0;
                    return largeur;
                }
                else
                {
                    largeur -= 3200;
                    return largeur;

                }
            }
        }

        /// <summary>
        /// Ajoute la largeur du bloc présedent au bloc sélectionné
        /// </summary>
        /// <param name="largeur"> Largeur du bloc  </param>
        /// <param name="selectedBloc"> Nouveau bloc a insérer</param>
        /// <param name="repere"> Repère indiqué par l'utilisateur dans la 3eme colone </param>
        /// <param name="numSymbole">Nombre de symbole total (Nombre de bloc unitaire) </param>
        /// <returns>Retourne un array de string comportant les lignes 
        /// avec l'ajout de la largeur aux coordonnées</returns>
        public static string[] addLargeur(int largeur, string selectedBloc, string repere, int numSymbole)
        {
            string ligne;
            int c = 0;
            int a = 0;
            int j = 0;
            int arc = 0;
            int n = 0;
            int vA = 0;
            int refe = 0;

            string tempSelectBloc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TempBloc\blocSelected\tempSelectedBloc.xrb";
            string[] finalTempBloc;
            List<string> s = new List<string>();

            if (File.Exists(tempSelectBloc))
            {
                File.Delete(tempSelectBloc);
                File.Copy(selectedBloc, tempSelectBloc);
            }
            else
            {
                File.Copy(selectedBloc, tempSelectBloc);
            }

            using (System.IO.StreamReader p = new StreamReader(tempSelectBloc, System.Text.Encoding.GetEncoding(1252)))
            {
                int compteur = 0;
                while ((ligne = p.ReadLine()) != null)
                {

                    if (compteur < 9)
                    {
                        compteur++;
                    }
                    else
                    {
                        if (ligne.StartsWith("¤#Symbole·0¤"))
                        {
                            // remplace le numero du symbole (ex: si 2ème bloc alors la ligne sera égale a "¤#Symbole·1¤" )
                            ligne = "¤#Symbole·" + numSymbole + "¤";

                        }
                        if ((c == 0) & (arc == 0) & (refe == 0) & (vA == 0))
                        {
                            if (ligne.StartsWith("¤#Autre¤"))
                            {
                                a = 1;


                            }
                            else if (a == 1)
                            {

                                if (!ligne.StartsWith("¤#"))
                                {
                                    if (j < 10)
                                    {

                                        if (j == 0)
                                        {

                                            string[] splitAutre = ligne.Split('·');
                                            string coordA = splitAutre[0];

                                            int coordA1 = 0;
                                            int coA = 0;
                                            if (Int32.TryParse(coordA, out coA))
                                            {
                                                coordA1 = coA;
                                            }

                                            coordA1 += largeur;

                                            splitAutre[0] = Convert.ToString(coordA1);

                                            ligne = String.Join("·", splitAutre);


                                        }
                                        else if (j == 2)
                                        {
                                            string[] splitAutre2 = ligne.Split('·');
                                            string coordA2 = splitAutre2[1];

                                            int coordA22 = 0;
                                            int coA2 = 0;

                                            if (Int32.TryParse(coordA2, out coA2))
                                            {
                                                coordA22 = coA2;
                                            }
                                            coordA22 += largeur;
                                            splitAutre2[0] = repere;
                                            splitAutre2[1] = Convert.ToString(coordA22);

                                            ligne = String.Join("·", splitAutre2);
                                        }
                                        else if (j >= 3)
                                        {
                                            string[] splitAutre3 = ligne.Split('·');
                                            string coordA3 = splitAutre3[1];

                                            int coordA33 = 0;
                                            int coA3 = 0;

                                            if (Int32.TryParse(coordA3, out coA3))
                                            {
                                                coordA33 = coA3;
                                            }
                                            coordA33 += largeur;

                                            splitAutre3[1] = Convert.ToString(coordA33);

                                            ligne = String.Join("·", splitAutre3);


                                        }



                                    }
                                    j++;

                                }
                                else { a = 2; }
                            }
                        }
                        if ((a >= 2) & (arc == 0) & (refe == 0) & (vA == 0))
                        {

                            if (ligne.StartsWith("¤#Contour¤"))
                            {
                                c = 1;

                            }
                            else if (c == 1)
                            {
                                if (!ligne.StartsWith("¤#"))
                                {
                                    //array de string délimité par le point (alt250)
                                    string[] split = ligne.Split('·');
                                    string strCoord1 = split[0];
                                    string strCoord2 = split[2];


                                    int coordX1 = 0;
                                    int coordX2 = 0;
                                    int co1 = 0;
                                    int co2 = 0;

                                    //Transformation du string en int
                                    if (Int32.TryParse(strCoord1, out co1))
                                    {
                                        coordX1 = co1;
                                    }
                                    if (Int32.TryParse(strCoord2, out co2))
                                    {
                                        coordX2 = co2;
                                    }

                                    //Ajout de la largeur
                                    coordX1 = coordX1 + largeur;
                                    coordX2 = coordX2 + largeur;

                                    //convertie le int en string et remplace la valeur dans le string array
                                    split[0] = Convert.ToString(coordX1);
                                    split[2] = Convert.ToString(coordX2);

                                    //Concaténation de l'array en string avec les points(alt250)
                                    ligne = String.Join("·", split);
                                }
                                else { c = 2; }
                            }
                        }

                        if ((c >= 2) & (a >= 2) & (refe == 0) & (vA == 0))
                        {
                            if (ligne.StartsWith("¤#Arc¤"))
                            {
                                arc = 1;

                            }
                            else if (arc == 1)
                            {
                                if (!ligne.StartsWith("¤#"))
                                {
                                    string[] splitArc = ligne.Split('·');
                                    string strCoordArc = splitArc[0];

                                    int coordArc = 0;
                                    int coArc = 0;

                                    if (Int32.TryParse(strCoordArc, out coArc))
                                    {
                                        coordArc = coArc;
                                    }
                                    coordArc += largeur;

                                    splitArc[0] = Convert.ToString(coordArc);
                                    ligne = String.Join("·", splitArc);




                                }
                                else { arc = 2; }
                            }
                        }
                        if ((c >= 2) & (a >= 2) & (arc >= 0) & (vA == 0))
                        {
                            if (ligne.StartsWith("¤#RefCroise¤"))
                            {
                                refe = 1;

                            }
                            else if (refe == 1)
                            {
                                if (!ligne.StartsWith("¤#"))
                                {
                                    string[] splitRef = ligne.Split('·');
                                    string strCoordRef = splitRef[5];

                                    int coordRef = 0;
                                    int coRef = 0;

                                    if (Int32.TryParse(strCoordRef, out coRef))
                                    {
                                        coordRef = coRef;
                                    }
                                    coordRef += largeur;

                                    splitRef[5] = Convert.ToString(coordRef);
                                    ligne = String.Join("·", splitRef);




                                }
                                else { refe = 2; }
                            }
                        }

                        if ((c >= 2) & (a >= 2) & (arc >= 2) & (refe >= 2))
                        {
                            if (ligne.StartsWith("¤#VueArmoire¤"))
                            {
                                vA = 1;

                            }
                            else if (vA == 1)
                            {
                                if (!ligne.StartsWith("¤#"))
                                {

                                    if (n <= 1)
                                    {
                                        if (n == 0)
                                        {
                                            string[] splitArmoire = ligne.Split('·');
                                            string coordArmoire = splitArmoire[1];

                                            int coordArmoire1 = 0;
                                            int coArmoire = 0;

                                            if (Int32.TryParse(coordArmoire, out coArmoire))
                                            {
                                                coordArmoire1 = coArmoire;
                                            }
                                            coordArmoire1 += largeur;

                                            splitArmoire[1] = Convert.ToString(coordArmoire1);

                                            ligne = String.Join("·", splitArmoire);

                                        }

                                    }
                                    n++;
                                }
                                else { vA = 2; }

                            }
                        }
                        s.Add(ligne);
                    }



                }
                finalTempBloc = s.ToArray();
                return finalTempBloc;
            }
        }

        /// <summary>
        /// Fonction qui ajoute les blocs unitaire supplémentaire (pas le premier bloc)
        /// </summary>
        /// <param name="pathTemp">Emplecement fichier temporaire</param>
        /// <param name="selectedBloc">Emplacement du bloc qui va être ajouté </param>
        /// <param name="repereChoix">Repère choisie par l'utilisateur (3eme colone)</param>
        /// <param name="numSymbole">Ajoute le numéro du bloc ( exemple: si 3eme bloc alors numSymbole = 2 )</param>
        public static void addBlock(string pathTemp, string selectedBloc, string repereChoix, int numSymbole)
        {
            int largeur = ElemBlocs.LargeurBloc(pathTemp);

            using (System.IO.StreamWriter block = new System.IO.StreamWriter(pathTemp, true, System.Text.Encoding.GetEncoding(1252)))
            {
                string[] blocPlusLargeur = ElemBlocs.addLargeur(largeur, selectedBloc, repereChoix, numSymbole);

                foreach (string i in blocPlusLargeur)
                {
                    block.WriteLine(i);
                }

            }


        }


        /// <summary>
        /// Fonction qui ajoute le premier bloc unitaire
        /// </summary>
        /// <param name="pathTemp">Emplacement du fichier temporaire</param>
        /// <param name="selectedBloc">Emplacement du bloc qui va être ajouté</param>
        /// <param name="nbrSymboles"></param>
        /// <param name="repereBloc"> Repère indiqué par l'utilisateur dans la 3eme colone selon le bloc</param>
        public static void addFirstBloc(string pathTemp, string selectedBloc, int nbrSymboles, string repereBloc)
        {
            //Compte le nombre de ligne du fiche de base
            var compteur = File.ReadAllLines(pathTemp).Length;

            using (System.IO.StreamWriter ok = new System.IO.StreamWriter(pathTemp, true, System.Text.Encoding.GetEncoding(1252)))
            {


                try
                {
                    if (compteur == 8)
                    {
                        string[] texteACopier = ElemBlocs.texteCopie(selectedBloc, nbrSymboles, repereBloc);

                        foreach (string i in texteACopier)
                        {
                            ok.WriteLine(i);
                        }

                    }
                }
                catch (IOException e11)
                {
                    Console.WriteLine(e11);
                }
            }
        }

        /// <summary>
        /// Fonction qui permet de copier les éléments du premier bloc dans un array de string avec changement
        /// du nombre de symbole et le repère du bloc, ici toujours 0 car premier bloc
        /// </summary>
        /// <param name="path">le chemin du bloc selectionné</param>
        /// <param name="nbrSymbole">nombre totale de symbole (de bloc unitaires)</param>
        /// <param name="unRepereBloc">Repère du premier bloc</param>
        /// <returns>Retourne un array de string comportant toutes les lignes du fichier avec les changemaent au 
        /// niveau du repère et du nombre de symbole</returns>
        public static string[] texteCopie(string path, int nbrSymbole, string unRepereBloc)
        {
            var texte = new List<string>();
            string line;
            int i = 0;
            int compteurS = 0;


            using (System.IO.StreamReader file = new System.IO.StreamReader(path, System.Text.Encoding.Default))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("¤#NombreSymbole¤"))
                    {
                        i = 1;

                    }
                    else if (i == 1)
                    {
                        if (!(line.StartsWith("¤#FIN¤")))
                        {
                            // ajoute le nombre totale de symboles 
                            if (compteurS == 0)
                            {
                                line = nbrSymbole + "·";
                                texte.Add(line);
                            }

                            // Ajoute le repère choisi par l'utilisateur
                            else if (compteurS == 5)
                            {
                                string[] spliter = line.Split('·');

                                spliter[0] = unRepereBloc;
                                line = String.Join("·", spliter);
                                texte.Add(line);
                            }
                            else
                            {
                                texte.Add(line);
                            }
                            compteurS++;
                        }
                    }
                    else { i = 0; }
                }
                texte.Add("¤#FIN¤");
                string[] res = texte.ToArray();
                return res;
            }

        }

        /// <summary>
        /// Fonction qui permet d'ajouter les lignes 
        /// qui ne changent jamais au début du fichier
        /// </summary>
        /// <param name="path">Emplacement du fichier temporaire </param>
        public static void addTexteNoChangement(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (!File.Exists(path))
            {

                using (FileStream fs = File.Create(path))
                {
                   
                }

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.GetEncoding(1252)))
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

        }

        /// <summary>
        /// fonction requête Insert database
        /// Insert dans la DB selon la requete en paramètre
        /// </summary>
        /// <param name="requestSQL"> Requete SQL</param>
        public static void requeteInsert(string requestSQL)
        {
            OleDbConnection cnn;
            OleDbCommand cmd;

            using (cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=S:\BE\ELECTRONIQUE\Echanges KBEAUDONNEL - JF PAILLOU\DBBlocs.accdb;"))
            {
                using (cmd = new OleDbCommand(requestSQL, cnn))
                {
                    cnn.Open();

                    //Execute la requête
                    cmd.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Requete select avec une seule colone en return
        /// </summary>
        /// <param name="requete">Requete SQL</param>
        /// <returns></returns>
        public static string[] requeteSelect(string requete)
        {
            OleDbConnection cnn;
            OleDbCommand cmd;
            DataTable result = new DataTable();


            using (cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=S:\BE\ELECTRONIQUE\Echanges KBEAUDONNEL - JF PAILLOU\DBBlocs.accdb;"))
            {
                using (cmd = new OleDbCommand(requete, cnn))
                {
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd))
                    {
                        dataAdapter.Fill(result);
                    }
                }

            }
            int columnIndex = 0;
            string[] array = new string[result.Rows.Count];
            for (int i = 0; i < result.Rows.Count; i++)
            {
                array[i] = result.Rows[i][columnIndex].ToString();
            }

            return array;
        }

        /// <summary>
        /// Requete select avec plusieurs colones en return
        /// </summary>
        /// <param name="requete">Requete SQL</param>
        /// <returns>Return une datatable </returns>
        public static DataTable requeteSelectMult(string requete)
        {
            OleDbConnection cnn;
            OleDbCommand cmd;
            DataTable dt = new DataTable();

            using (cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=S:\BE\ELECTRONIQUE\Echanges KBEAUDONNEL - JF PAILLOU\DBBlocs.accdb;"))
            {
                using (cmd = new OleDbCommand(requete, cnn))
                {
                    cnn.Open();
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                    return dt;
                }
            }
        }

        /// <summary>
        /// Fonction qui permet de convertir un array de string en string
        /// </summary>
        /// <param name="array">Un array de string a convertir</param>
        /// <returns>return un string contenant tous les string contenues dans l'array</returns>
        public static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
            }
            return builder.ToString();
        }
    }  
}

            
   
