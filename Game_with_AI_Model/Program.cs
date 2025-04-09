using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_with_AI_Model
{
    internal class Program
    {
       

        public class Character
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<string> Abilities { get; set; }
            public int Health { get; set; }
            public int Level { get; set; }
            public int Experience { get; set; }
            public string Class { get; set; }
            public int Age { get; set; }
            public string Appearance { get; set; }
            public string Personality { get; set; }
            public string Objective { get; set; }

            public Character(string name, string description, List<string> abilities, string characterClass, int age, string appearance, string personality, string objective, int health = 100, int level = 1, int experience = 0)
            {
                Name = name;
                Description = description;
                Abilities = abilities;
                Class = characterClass;
                Age = age;
                Appearance = appearance;
                Personality = personality;
                Objective = objective;
                Health = health;
                Level = level;
                Experience = experience;
            }

            public void GainExperience(int amount)
            {
                Experience += amount;
                if (Experience >= 100) // Por ejemplo, 100 puntos para subir de nivel
                {
                    LevelUp();
                }
            }

            private void LevelUp()
            {
                Level++;
                Experience = 0; // Reiniciar experiencia al subir de nivel
                Health += 20; // Aumentar salud al subir de nivel
                Console.WriteLine($"{Name} ha subido al nivel {Level}!");
            }
        }


        public class Game
        {
            private List<Character> characters;
            private static StoryLibrary.Class1.Historia historia;

            public Game()
            {
                characters = new List<Character>();
                InitializeCharacters();
            }

            private void InitializeCharacters()
            {
                characters.Add(new Character(
                    "Haruki",
                    "Un ronin que lucha con su pasado y busca un nuevo propósito en la vida.",
                    new List<string> { "Maestro de la espada", "Tácticas de guerrilla", "Resistencia emocional" },
                    "Ronin (Guerrero)",
                    30,
                    "Alto y de complexión atlética, con cabello oscuro y desordenado. Lleva una armadura ligera y una capa desgastada.",
                    "Melancólico, honor y lealtad, mentor.",
                    "Buscar redención y un nuevo propósito en la vida, protegiendo a su nueva comunidad."
                ));

                characters.Add(new Character(
                    "Yuki",
                    "Una joven que representa la esperanza y la inocencia.",
                    new List<string> { "Curación", "Inmunidad emocional", "Sigilo" },
                    "Sanadora/Apoyo",
                    18,
                    "De estatura media, con cabello largo y oscuro, a menudo trenzado. Viste ropas sencillas de campesina.",
                    "Optimista, compasiva, curiosa.",
                    "Proteger a su aldea y ayudar a Haruki a encontrar su camino."
                ));

                characters.Add(new Character(
                    "Takeshi",
                    "Un antiguo rival que busca venganza.",
                    new List<string> { "Fuerza bruta", "Estratega", "Intimidación" },
                    "Guerrero/Antagonista",
                    32,
                    "Alto y musculoso, con cicatrices visibles. Lleva una armadura pesada y una katana ornamentada.",
                    "Vengativo, orgulloso, carismático.",
                    "Buscar venganza contra Haruki por un antiguo rencor."
                ));
            }

            public void ShowCharacters()
            {
                Console.WriteLine("Personajes disponibles:");
                for (int i = 0; i < characters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {characters[i].Name} - {characters[i].Description} (Clase: {characters[i].Class}, Edad: {characters[i].Age})");
                }
            }

            public void Separador()
            {
                Console.WriteLine();
            }

            public void PlayGame()
            {
                //Inicialización del juego
                Console.WriteLine("Bienvenido a 'El Camino del Ronin'.");
                Separador();
                //Introducción al juego
                Console.WriteLine("En el Japón feudal, un ronin llamado Haruki busca redención tras la muerte de su maestro,\nmientras se enfrenta a un mundo lleno de conflictos y dilemas morales.");
                Separador();
                // Se inicializan los personajes
                ShowCharacters();

                // Seleccionar personaje
                Console.Write("Selecciona un personaje (1, 2, 3): ");
                if (int.TryParse(Console.ReadLine(), out int personajeSeleccionado) && personajeSeleccionado >= 1 && personajeSeleccionado <= 3)
                {
                    switch (personajeSeleccionado)
                    {
                        case 1:
                            // Inicializar la instancia de Historia
                            historia = new StoryLibrary.Class1.Historia();

                            // Obtener el escenario inicial
                            var escenarioActual1 = historia.Escenarios[0];

                            // Bucle para navegar a través de la historia
                            while (true)
                            {
                                // Mostrar la descripción del escenario actual
                                Console.WriteLine(escenarioActual1.Descripcion);

                                // Mostrar las decisiones disponibles
                                foreach (var decision in escenarioActual1.Decisiones)
                                {
                                    Console.WriteLine($"{decision.Key}. {decision.Value.Texto}");
                                }

                                // Leer la elección del usuario
                                Console.Write("Elige una opción: ");
                                if (int.TryParse(Console.ReadLine(), out int eleccion) && escenarioActual1.Decisiones.ContainsKey(eleccion))
                                {
                                    // Actualizar el escenario actual basado en la elección del usuario
                                    escenarioActual1 = escenarioActual1.ObtenerSiguienteEscenario(eleccion);

                                    // Si no hay más decisiones, se ha alcanzado un final
                                    if (escenarioActual1.Decisiones.Count == 0)
                                    {
                                        Console.WriteLine(escenarioActual1.Descripcion);
                                        Console.WriteLine("Fin de la historia.");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                                }

                                // Separador para la siguiente iteración
                                Separador();
                            }
                            break;

                        case 2:
                            // Inicializar la instancia de Historia de YukiStoryLibrary
                            var yukiHistoria = new YukiStoryLibrary.Class1.Historia();

                            // Obtener el escenario inicial
                            var escenarioActual2 = yukiHistoria.Escenarios[0];

                            // Bucle para navegar a través de la historia
                            while (true)
                            {
                                // Mostrar la descripción del escenario actual
                                Console.WriteLine(escenarioActual2.Descripcion);

                                // Mostrar las decisiones disponibles
                                foreach (var decision in escenarioActual2.Decisiones)
                                {
                                    Console.WriteLine($"{decision.Key}. {decision.Value.Texto}");
                                }

                                // Leer la elección del usuario
                                Console.Write("Elige una opción: ");
                                if (int.TryParse(Console.ReadLine(), out int eleccion) && escenarioActual2.Decisiones.ContainsKey(eleccion))
                                {
                                    // Actualizar el escenario actual basado en la elección del usuario
                                    escenarioActual2 = escenarioActual2.ObtenerSiguienteEscenario(eleccion);

                                    // Si no hay más decisiones, se ha alcanzado un final
                                    if (escenarioActual2.Decisiones.Count == 0)
                                    {
                                        Console.WriteLine(escenarioActual2.Descripcion);
                                        Console.WriteLine("Fin de la historia.");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada no válida. Inténtalo de nuevo.");
                                }

                                // Separador para la siguiente iteración
                                Separador();

                            }
                            break;
                         
                        case 3:
                            //Inicializar la la Instancia de Historia de TakeshiStoryLibrary
                            var takeshiHistoria = new TakeshiStoryLibrary.Class1.HistoriaVillano();

                            // Obtener el escenario inicial
                            var escenarioActual3 = takeshiHistoria.Escenarios[0];

                            // Bucle para navegar a través de la historia
                            while (true)
                            {
                                // Mostrar la descripción del escenario actual
                                Console.WriteLine(escenarioActual3.Descripcion);

                                // Mostrar las decisiones disponibles
                                foreach (var decision in escenarioActual3.Decisiones)
                                {
                                    Console.WriteLine($"{decision.Key}. {decision.Value.Texto}");
                                }

                                // Leer la elección del usuario
                                Console.Write("Elige una opción: ");
                                if (int.TryParse(Console.ReadLine(), out int eleccion) && escenarioActual3.Decisiones.ContainsKey(eleccion))
                                {
                                    // Actualizar el escenario actual basado en la elección del usuario
                                    escenarioActual3 = escenarioActual3.ObtenerSiguienteEscenario(eleccion);

                                    // Si no hay más decisiones, se ha alcanzado un final
                                    if (escenarioActual3.Decisiones.Count == 0)
                                    {
                                        Console.WriteLine(escenarioActual3.Descripcion);
                                        Console.WriteLine("Fin de la historia.");
                                        break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                                }

                                // Separador para la siguiente iteración
                                Separador();

                            }
                            break;

                        default:
                            Console.WriteLine("Selección no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Selección no válida.");
                }
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
        }

    }
}
