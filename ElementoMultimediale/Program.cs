using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace ElementoMultimediale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CMultimediale[] elementi = new CMultimediale[5];

            for (int i = 0; i < elementi.Length; i++)
            {
                Console.WriteLine("Scegli un elemento multimediale da creare: \n1. Immagine \n2. Audio \n3. Video");
                int scelta = int.Parse(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserisci il nome dell'immagine:");
                        string nomeImg = Console.ReadLine();
                        Console.WriteLine("Inserisci la luminosita` (1-10):");
                        int lum = int.Parse(Console.ReadLine());
                        elementi[i] = new CImmagine(nomeImg, lum);
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il nome dell'audio:");
                        string nomeAudio = Console.ReadLine();
                        Console.WriteLine("Inserisci il volume (1-10):");
                        int vol = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserisci la durata:");
                        int dur = int.Parse(Console.ReadLine());
                        elementi[i] = new CAudio(nomeAudio, vol, dur);
                        break;
                    case 3:
                        Console.WriteLine("Inserisci il nome del video:");
                        string nomeVid = Console.ReadLine();
                        Console.WriteLine("Inserisci il volume (1-10):");
                        int volVid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserisci la luminosita` (1-10):");
                        int lumVid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserisci la durata:");
                        int durVid = int.Parse(Console.ReadLine());
                        elementi[i] = new CVideo(volVid, nomeVid, lumVid, durVid);
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        i--;
                        break;
                }
            }

            Console.WriteLine("\nRiproduzione degli elementi multimediali:\n");

            bool state = true;
            do
            {

                int oggettoSelezionato;
                do
                {
                    Console.WriteLine("Scegliere oggetto su cui operare (1-5): ");
                } while (!int.TryParse(Console.ReadLine(), out oggettoSelezionato) || oggettoSelezionato < 1 || oggettoSelezionato > 5);

                CMultimediale elemento = elementi[oggettoSelezionato - 1];

                int input;

                do
                {
                    Console.WriteLine("Scegliere operazione da eseguire: \n1. Modifica elemento \n2. Stampa film con durata minima \n3. Stampa elementi ordinati per durata \n4. Confronta film\nAltro. Esci");
                } while (!int.TryParse(Console.ReadLine(), out input) || oggettoSelezionato < 1 || oggettoSelezionato > 5);


                switch (input)
                {
                    case 1:
                        if (elemento is CVideo)
                        {
                            ModificaVideo((CVideo)elemento);
                        }
                        else if (elemento is CAudio)
                        {
                            ModificaAudio((CAudio)elemento);
                        }
                        else
                        {
                            ModificaImmagine((CImmagine)elemento);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Inserisci una durata filtro: ");
                        int dMin = int.Parse(Console.ReadLine());
                        StampaFilmDurataMinima(elementi, dMin);
                        break;
                    case 3:
                        StampaElementiOrdinatiPerDurata(elementi);
                        break;
                    case 4:
                        if (elemento is CVideo)
                        {

                            int sceltaFilm;
                            do
                            {
                                Console.WriteLine("Scegliere altro film: ");
                            } while (!int.TryParse(Console.ReadLine(), out sceltaFilm)
                                     || sceltaFilm < 1
                                     || sceltaFilm > elementi.Length
                                     || elementi[sceltaFilm - 1] == null
                                     || !(elementi[sceltaFilm - 1] is CVideo));

                            CVideo altroFilm = (CVideo)elementi[sceltaFilm - 1];
                            ComparaFilm(elemento, altroFilm);
                        }
                        else
                        {
                            Console.WriteLine("L'elemento selezionato non e` un video.");
                        }
                        break;
                    default:
                        Console.WriteLine("Chiusura in corso");
                        return;
                        break;
                }
            } while (state);
        }

        private static void ModificaImmagine(CImmagine elemento)
        {
            Console.WriteLine("Modifica luminosita` immagine: \n1. Aumenta luminosita` \n2. Diminuisci luminosita`");
            int sceltaLum = int.Parse(Console.ReadLine());
            switch (sceltaLum)
            {
                case 1:
                    elemento.Brighter();
                    break;
                case 2:
                    elemento.Darker();
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        private static void ModificaAudio(CAudio elemento)
        {
            Console.WriteLine("Modifica luminosita` immagine: \n1. Aumenta luminosita` \n2. Diminuisci luminosita`");
            int sceltaLum = int.Parse(Console.ReadLine());
            switch (sceltaLum)
            {
                case 1:
                    elemento.Louder();
                    break;
                case 2:
                    elemento.Weaker();
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        private static void ModificaVideo(CVideo elemento)
        {
            Console.WriteLine("Modifica video: \n1. Aumenta luminosita` \n2. Diminuisci luminosita` \n3. Aumenta audio \n4. Diminuisci audio");
            int sceltaLum = int.Parse(Console.ReadLine());
            switch (sceltaLum)
            {
                case 1:
                    elemento.Brighter();
                    break;
                case 2:
                    elemento.Darker();
                    break;
                case 3:
                    elemento.Louder();
                    break;
                case 4:
                    elemento.Weaker();
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        private static void StampaFilmDurataMinima(CMultimediale[] elementi, int dMin)
        {

            foreach (var elemento in elementi)
            {
                if (elemento is CVideo)
                {
                    if (((CVideo)elemento).d >= dMin)
                    {
                        Console.WriteLine(elemento.ToString());
                    }
                }
            }
        }

        private static void StampaElementiOrdinatiPerDurata(CMultimediale[] elementi)
        {
            List<CVideo> videoList = new List<CVideo>();
            foreach (var elemento in elementi)
            {
                if (elemento is CVideo)
                {
                    videoList.Add((CVideo)elemento);
                }
            }
            videoList.Sort();
            Console.WriteLine("Elementi video ordinati per durata:");
            foreach (var video in videoList)
            {
                Console.WriteLine(video.ToString());
            }
        }

        private static void ComparaFilm(CMultimediale elemento, CVideo altroFilm)
        {
            if ((CVideo)elemento == altroFilm)
            {
                Console.WriteLine("I due film hanno durata uguale");
            }
            else
            {
                Console.WriteLine("I due film hanno durata diversa");
            }
        }
    }
}