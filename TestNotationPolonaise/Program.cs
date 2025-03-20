using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Calcule le résultat d'une expression en notation polonaise.
        /// </summary>
        /// <param name="formule">>La chaîne représentant l'expression en notation polonaise</param>
        /// <returns></returns>
        static float Polonaise(String formule)
        {
            try
            {
                float result;
                string[] vec = formule.Split(' ');
                int nbCases = vec.Length;

                for (int k = nbCases - 1; k >= 0; k--)
                {
                    // Vérifier si la case contient un opérateur
                    if (vec[k] == "+" || vec[k] == "-" || vec[k] == "*" || vec[k] == "/")
                    {
                        // Conversion des opérandes en float
                        float op1 = float.Parse(vec[k + 1]);
                        float op2 = float.Parse(vec[k + 2]);
                        float resultat = 0;

                        // Calcul en fonction de l'opérateur
                        switch (vec[k])
                        {
                            case "+": resultat = op1 + op2; break;
                            case "-": resultat = op1 - op2; break;
                            case "*": resultat = op1 * op2; break;
                            case "/":
                                // Vérification pour éviter la division par zéro
                                if (op2 == 0)
                                    return float.NaN;
                                else
                                    resultat = op1 / op2;
                                break;
                        }

                        // Remplacer l'opérateur par le résultat (converti en chaîne)
                        vec[k] = resultat.ToString();

                        // décalage du tableau
                        for (int j = k + 1; j < nbCases - 2; j++)
                        {
                            vec[j] = vec[j + 2];
                        }

                        // Mettre à jour le nombre effectif de cases
                        nbCases -= 2;
                    }
                }

                // Si la formule n'est pas valide (par exemple, "4 3" ne contient pas d'opérateur)
                if (nbCases != 1)
                    return float.NaN;
                // résultat dans la première case
                return float.Parse(vec[0]);
            }
            catch
            {
                return float.NaN;
            }
        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                String laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
