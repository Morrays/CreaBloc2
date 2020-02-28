using System;
using System.Collections.Generic;
using System.IO;

namespace CreaBloc2
{
    //classe des composants du bloc
    class ElemBlocs
    {
        public static int LargeurBloc(String chemin)
        {
            int largeur = 0;


            using (System.IO.StreamReader sr = new System.IO.StreamReader(chemin, System.Text.Encoding.UTF8))
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

        //Ajoute la largeur choisi au bloc sélectionné
        public static string[] addLargeur(int largeur, string selectedBloc)
        {
            string ligne;
            int c = 0;
            int a = 0;
            int j = 0;
            string tempSelectBloc = @"C:\Users\beaudonnelk\Documents\TempBloc\blocSelected\tempSelectedBloc.xrb";
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

            using (System.IO.StreamReader p = new StreamReader(tempSelectBloc, System.Text.Encoding.Default))
            {
                while ((ligne = p.ReadLine()) != null)
                {
                    if (ligne.StartsWith("¤#Autre¤"))
                    {
                        a = 1;

                    }
                    else if (a == 1)
                    {

                        if (!ligne.StartsWith("¤#"))
                        {

                            if (j < 9)
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

                                    string ligneOutputAutre = String.Join("·", splitAutre);
                                    s.Add(ligneOutputAutre);

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

                                    splitAutre2[1] = Convert.ToString(coordA22);

                                    string ligneOutputAutre2 = String.Join(".", splitAutre2);
                                    s.Add(ligneOutputAutre2);

                                }
                                else if (j == 3)
                                {
                                    string[] splitAutre3 = ligne.Split('·');
                                    Console.WriteLine(splitAutre3[1]);
                                    string coordA3 = splitAutre3[1];

                                    int coordA33 = 0;
                                    int coA3 = 0;

                                    if (Int32.TryParse(coordA3, out coA3))
                                    {
                                        coordA33 = coA3;
                                    }
                                    coordA33 += largeur;

                                    splitAutre3[1] = Convert.ToString(coordA33);

                                    string ligneOutputAutre3 = String.Join(".", splitAutre3);
                                    s.Add(ligneOutputAutre3);
                                    

                                }
                                else if (j > 3)
                                {                                   
                                    string[] splitAutreX = ligne.Split('.');
                                    string coordAX = splitAutreX[1];

                                    int coordAXX = 0;
                                    int coAX = 0;

                                    if (Int32.TryParse(coordAX, out coAX))
                                    {
                                        coordAXX = coAX;
                                    }
                                    coordAXX += largeur;

                                    splitAutreX[1] = Convert.ToString(coordAXX);

                                    string ligneOutputAutreX = String.Join(".", splitAutreX);
                                    s.Add(ligneOutputAutreX);
                                }
                            }
                            j++;
                        }
                    }
                    else { a = 0; }

                }

                if (ligne.StartsWith(@"¤#Contour¤"))
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
                        string ligneOutput = String.Join("·", split);

                        ligne = ligneOutput;

                        //ajout de la ligne avec la nouvelle valeur a l'array de string
                        s.Add(ligne);

                    }
                    else { c = 0; }
                }
                else if (ligne.StartsWith("¤#Arc¤"))
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
                    string ligneOutputArc = String.Join("·", splitArc);

                    ligne = ligneOutputArc;

                    s.Add(ligne);


                }
                else
                {
                    s.Add(ligne);
                }
            }
            finalTempBloc = s.ToArray();
            return finalTempBloc;
        }

        public static void addBlock(string pathTemp, string selectedBloc)
        {
            int largeur = ElemBlocs.LargeurBloc(pathTemp);

            using (System.IO.StreamWriter block = new System.IO.StreamWriter(pathTemp, true))
            {
                string[] blocPlusLargeur = ElemBlocs.addLargeur(largeur, selectedBloc);

                foreach (string i in blocPlusLargeur)
                {
                    block.WriteLine(i);
                }

            }


        }


        // Copie les ligne du bloc choisi dans le nouveau bloc
        public static void addFirstBloc(string pathTemp, string selectedBloc)
        {
            //Compte le nombre de ligne du fiche de base
            var compteur = File.ReadAllLines(pathTemp).Length;

            using (System.IO.StreamWriter ok = new System.IO.StreamWriter(pathTemp, true))
            {


                try
                {
                    if (compteur == 8)
                    {
                        string[] texteACopier = ElemBlocs.texteCopie(selectedBloc);

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

        //Retourne un array de string comportant toutes les lignes du bloc slélectionné
        public static string[] texteCopie(string path)
        {
            var texte = new List<string>();
            string line;
            int i = 0;


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
                            texte.Add(line);
                        }
                    }
                    else { i = 0; }
                }
                texte.Add("¤#FIN¤");
                string[] res = texte.ToArray();
                return res;
            }

        }
    }
}
            
   
