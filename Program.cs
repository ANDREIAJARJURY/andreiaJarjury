using System;
using System.Threading;

namespace SimuladorNexus
{
    // ========================================================
    // MISIÓN 01 - NEXUS TRANSMUTATION (POO)
    // Entidad transformada: Explorador
    // ========================================================
    class Explorador
    {
        // 1. Atributos encapsulados (private) con descriptores de acceso (Propiedades)
        private string nombre;
        private int edad;
        private string realidadAsignada;
        private int energia;
        private int estabilidad;

        public int NivelPeligro { get; set; }
        public bool EscudoActivo { get; set; }
        public bool ModoSobrecarga { get; set; }
        public int SectoresExplorados { get; set; }

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public string RealidadAsignada { get { return realidadAsignada; } set { realidadAsignada = value; } }

        // Encapsulamiento: Protegiendo que la energía no sea negativa ni mayor a 100
        public int Energia
        {
            get { return energia; }
            set
            {
                if (value < 0) energia = 0;
                else if (value > 100) energia = 100;
                else energia = value;
            }
        }

        // Encapsulamiento: Protegiendo que la estabilidad no sea negativa ni mayor a 100
        public int Estabilidad
        {
            get { return estabilidad; }
            set
            {
                if (value < 0) estabilidad = 0;
                else if (value > 100) estabilidad = 100;
                else estabilidad = value;
            }
        }

        // 2. Constructor: Cómo nace la entidad
        public Explorador(string _nombre, int _edad, string _realidad, int _energiaInicial, int _estabilidadInicial)
        {
            this.Nombre = _nombre;
            this.Edad = _edad;
            this.RealidadAsignada = _realidad;
            this.Energia = _energiaInicial;
            this.Estabilidad = _estabilidadInicial;

            this.NivelPeligro = 1;
            this.EscudoActivo = false;
            this.ModoSobrecarga = false;
            this.SectoresExplorados = 0;
        }

        // 3. Métodos propios de la clase Explorador (Nuevas funcionalidades narrativas)

        // Método que representa recibir daño de una anomalía
        public void RecibirDanoAnomalia(int danoEnergia, int danoEstabilidad)
        {
            if (this.EscudoActivo)
            {
                // Si el escudo está activo, mitiga el daño de estabilidad
                this.Energia -= danoEnergia;
                Console.WriteLine($"> [SISTEMA] El escudo de {this.Nombre} resistió la anomalía. (-{danoEnergia}% Energía)");
            }
            else
            {
                this.Energia -= danoEnergia + 10; // Penalidad por no tener escudo
                this.Estabilidad -= danoEstabilidad;
                Console.WriteLine($"> [SISTEMA] ¡Impacto directo! {this.Nombre} sufrió daños críticos. (-{danoEnergia + 10}% E, -{danoEstabilidad}% Est)");
            }
        }

        // Método para procesar el descanso y recuperación
        public void Descansar()
        {
            int ganancia = this.ModoSobrecarga ? 40 : 25;
            this.Energia += ganancia;

            if (this.Estabilidad > 50 && this.NivelPeligro > 1)
            {
                this.NivelPeligro--;
            }
            Console.WriteLine($"> [SISTEMA] {this.Nombre} ha recargado sus sistemas (+{ganancia}% Energía).");
        }
    }

    class Program
    {
        // El cadete principal ahora se inicializa temporalmente con el constructor (se sobrescribe en el Main)
        static Explorador cadete = new Explorador("Desconocido", 0, "Ninguna", 100, 100);

        // NUEVO OBJETO DEMOSTRATIVO (Segundo objeto de la clase Explorador para probar POO)
        static Explorador exploradorCaido = new Explorador("Vanguard-01", 30, "IRIS-07", 15, 10);

        static bool conectado = true;

        static string[] listaRealidades = { "IRIS-07 // Valle de Cristal", "IRIS-12 // Sector Abisal", "IRIS-21 // Zona de Interferencia" };
        static char[][,] mapasNEXUS = new char[3][,];

        static void Main(string[] args)
        {
            InicializarMapas();

            Console.Clear();
            DibujarEncabezado();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("             NEXUS v1.1 - TRANSMUTATION POO          ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("=================================================\n");

            Console.Write("Ingrese su Nombre de Explorador: ");
            string nom = Console.ReadLine();

            int ed = LeerEntero("Ingrese su Edad: ", 15, 99);

            Console.Write("Ingrese su Realidad asignada (ej. Sector 7-G): ");
            string real = Console.ReadLine();

            int ene = LeerEntero("Ingrese Nivel de energía inicial (0-100): ", 0, 100);
            int est = LeerEntero("Ingrese Nivel de estabilidad inicial (0-100): ", 0, 100);

            // INSTANCIACIÓN POO: Creando al objeto principal usando el Constructor en tiempo real
            cadete = new Explorador(nom, ed, real, ene, est);

            MostrarAnimacionEscaneo("Evaluando condiciones ambientales de la realidad...");

            if (cadete.Energia >= 30 && cadete.Estabilidad >= 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n>>> INMERSIÓN AUTORIZADA <<<");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Presione cualquier tecla para acceder al centro de mando...");
                Console.ReadKey();
                BucleSimulacion();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n>>> INMERSIÓN RECHAZADA <<<");
                Console.ReadKey();
            }
        }

        static void InicializarMapas()
        {
            mapasNEXUS[0] = new char[,] {
                { '▓', '▓', '▓', '▓', '▓', '▓', '▓', '▓' },
                { '▓', '⌂', '·', '·', '◆', '·', '?', '▓' },
                { '▓', '·', '▓', '▓', '·', '⚠', '?', '▓' },
                { '▓', '◆', '·', '●', '·', '·', '?', '▓' },
                { '▓', '▓', '▓', '▓', '▓', '▓', '▓', '▓' }
            };

            mapasNEXUS[1] = new char[,] {
                { '▓', '▓', '▓', '·', '·', '·', '≈', '≈' },
                { '▓', '⌂', '▓', '·', '◆', '·', '≈', '⚠' },
                { '▓', '▓', '▓', '·', '·', '·', '≈', '≈' },
                { '?', '?', '?', '?', '?', '?', '?', '?' }
            };

            mapasNEXUS[2] = new char[,] {
                { '?', '?', '?', '?', '?', '?', '?' },
                { '?', '?', '?', '⚠', '?', '?', '?' },
                { '?', '?', '?', '?', '?', '?', '?' }
            };
        }

        static void MenuCartografia()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║       NEXUS // MAPAS DE REALIDADES     ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║                                        ║");

            for (int i = 0; i < listaRealidades.Length; i++)
            {
                Console.WriteLine($"║ [{i + 1}] {listaRealidades[i],-33}║");
            }
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.Gray;

            int seleccion = LeerEntero("\nSeleccione una realidad a visualizar (1-3): ", 1, 3);
            int indiceMapa = seleccion - 1;

            if (indiceMapa != 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[RETO ÉLITE] La realidad {listaRealidades[indiceMapa]} no está en almacenamiento local.");
                MostrarAnimacionEscaneo($"Solicitando cartografía al NEXUS B...");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.Clear();
            DibujarMapa(indiceMapa);
        }

        static void DibujarMapa(int indice)
        {
            char[,] mapaActual = mapasNEXUS[indice];
            int filas = mapaActual.GetLength(0);
            int columnas = mapaActual.GetLength(1);
            int zonasExploradas = 0, zonasTotales = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- CARTOGRAFÍA: {listaRealidades[indice]} ---");
            Console.WriteLine("LEYENDA: [⌂] Base  [◆] Recurso  [⚠] Anomalía  [●] P. Interés  [·] Registrado  [?] Desconocido  [▓] Límite  [≈] Interferencia\n");

            for (int y = 0; y < filas; y++)
            {
                Console.Write("    ");
                for (int x = 0; x < columnas; x++)
                {
                    char celda = mapaActual[y, x];
                    zonasTotales++;

                    switch (celda)
                    {
                        case '⌂': Console.ForegroundColor = ConsoleColor.Blue; zonasExploradas++; break;
                        case '◆': Console.ForegroundColor = ConsoleColor.Green; zonasExploradas++; break;
                        case '⚠': Console.ForegroundColor = ConsoleColor.Red; zonasExploradas++; break;
                        case '●': Console.ForegroundColor = ConsoleColor.Magenta; zonasExploradas++; break;
                        case '·': Console.ForegroundColor = ConsoleColor.Gray; zonasExploradas++; break;
                        case '?': Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        case '▓': Console.ForegroundColor = ConsoleColor.DarkGray; zonasExploradas++; break;
                        case '≈': Console.ForegroundColor = ConsoleColor.DarkCyan; zonasExploradas++; break;
                    }
                    Console.Write(celda + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            double porcentaje = ((double)zonasExploradas / zonasTotales) * 100;
            Console.WriteLine($"\nESTADO: Coordenadas Totales: {zonasTotales} | Nivel de Cartografía: {porcentaje:F1}%");
            Console.WriteLine("\nPresione cualquier tecla para volver al centro de mando...");
            Console.ReadKey();
        }

        static void BucleSimulacion()
        {
            while (conectado)
            {
                Console.Clear();
                DibujarPanelEstado();

                Console.WriteLine("\nMENÚ DE OPERACIONES DISPONIBLES:");
                Console.WriteLine("1. Explorar realidad");
                Console.WriteLine("2. Analizar anomalía ambiental");
                Console.WriteLine("3. Gestor de Escudo y Sobrecarga");
                Console.WriteLine("4. Recuperar recursos y estabilizar");
                Console.WriteLine("5. MAPAS DE REALIDADES");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("6. Misión de Rescate (Interactuar con otro Objeto)");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("7. Finalizar sesión de inmersión");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nSeleccione una opción (1-7): ");

                string opcion = Console.ReadLine();
                Console.WriteLine("\n--------------------------------------------------");

                switch (opcion)
                {
                    case "1": Explorar(); break;
                    case "2": Analizar(); break;
                    case "3": GestionarEscudo(); break;
                    case "4":
                        MostrarAnimacionEscaneo("Recargando celdas...");
                        cadete.Descansar(); // <--- Llamada a método encapsulado en POO
                        break;
                    case "5": MenuCartografia(); break;
                    case "6": RescatarExplorador(); break; // <--- Nueva funcionalidad POO
                    case "7": conectado = false; Console.WriteLine("Cerrando sesión de inmersión de forma ordenada..."); break;
                    default: Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Opción no válida."); Console.ForegroundColor = ConsoleColor.Gray; break;
                }

                VerificarSituacionCritica();
                VerificarNivelElite();

                if (conectado && opcion != "5")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==================================================");
            Console.WriteLine("              TRANSMISIÓN FINAL NEXUS             ");
            Console.WriteLine("==================================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Has completado la sesión en NEXUS v1.1.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }

        // ========================================================
        // NUEVA FUNCIONALIDAD POO: Interacción entre dos objetos
        // ========================================================
        static void RescatarExplorador()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠ SEÑAL DE SOCORRO DETECTADA DE: {exploradorCaido.Nombre} en {exploradorCaido.RealidadAsignada}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Estado de {exploradorCaido.Nombre} -> Energía: {exploradorCaido.Energia}% | Estabilidad: {exploradorCaido.Estabilidad}%");

            if (cadete.Energia > 40)
            {
                Console.WriteLine("\nIniciando transferencia de energía al explorador caído...");
                MostrarAnimacionEscaneo("Transfiriendo recursos...");

                // Interacción entre dos objetos instanciados de la clase Explorador
                cadete.Energia -= 30;          // El objeto principal pierde energía
                exploradorCaido.Energia += 30; // El segundo objeto gana energía
                exploradorCaido.Estabilidad += 20;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"¡Rescate exitoso! {exploradorCaido.Nombre} ha sido estabilizado.");
                Console.WriteLine($"Tus recursos tras el rescate: Energía actual: {cadete.Energia}%");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Tu energía actual ({cadete.Energia}%) es insuficiente para una transferencia segura.");
                Console.WriteLine("El rescate ha sido abortado.");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Explorar()
        {
            if (cadete.Energia < 25 || cadete.Estabilidad < 25)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("⚠ ADVERTENCIA: Niveles en rango crítico. ¿Desea explorar de todos modos? (S/N): ");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (Console.ReadLine().Trim().ToUpper() != "S") return;
            }

            if (cadete.Energia < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ ACCIÓN RECHAZADA: Energía insuficiente.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            MostrarAnimacionEscaneo("Desplegando sondas de exploración...");

            if (cadete.Energia > 50 && cadete.Estabilidad > 50)
            {
                cadete.Energia -= 10;
                cadete.Estabilidad -= 5;
                cadete.SectoresExplorados++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("🟢 Exploración óptima: -10% Energía, -5% Estabilidad.");
            }
            else if (cadete.EscudoActivo)
            {
                cadete.Energia -= 20;
                cadete.SectoresExplorados++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("🔵 Exploración con Escudo: 0% pérdida de Estabilidad, -20% Energía.");
            }
            else if (cadete.Estabilidad <= 40 || cadete.ModoSobrecarga)
            {
                cadete.Energia -= 15;
                cadete.Estabilidad -= 20;
                cadete.SectoresExplorados++;
                if (cadete.NivelPeligro < 5) cadete.NivelPeligro++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("🟡 Exploración Inestable: -15% Energía, -20% Estabilidad.");
            }
            else
            {
                cadete.Energia -= 15;
                cadete.Estabilidad -= 10;
                cadete.SectoresExplorados++;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("🟠 Exploración de Riesgo: -15% Energía, -10% Estabilidad.");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Analizar()
        {
            if (cadete.Energia < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ ACCIÓN RECHAZADA: Energía insuficiente.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            MostrarAnimacionEscaneo("Ejecutando algoritmo de escaneo...");

            if (cadete.Estabilidad < 35 && cadete.NivelPeligro >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("⚠ ANOMALÍA AMBIENTAL DETECTADA");
                Console.ForegroundColor = ConsoleColor.Gray;

                // <--- Llamada a método encapsulado en POO
                cadete.RecibirDanoAnomalia(15, 15);
            }
            else
            {
                cadete.Energia -= 10;
                cadete.Estabilidad += 5;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Análisis exitoso: -10% Energía, +5% Estabilidad.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void GestionarEscudo()
        {
            Console.WriteLine("GESTOR TÁCTICO:");
            Console.WriteLine($"Escudo: {(cadete.EscudoActivo ? "ACTIVADO" : "DESACTIVADO")}");
            Console.WriteLine($"Sobrecarga: {(cadete.ModoSobrecarga ? "ACTIVO" : "INACTIVO")}");
            Console.WriteLine("1. Alternar Escudo (-5% Energía)");
            Console.WriteLine("2. Alternar Sobrecarga (+ Regeneración, + Peligro)");
            Console.Write("Opción: ");

            string subOpcion = Console.ReadLine();
            if (subOpcion == "1" && cadete.Energia >= 5)
            {
                cadete.Energia -= 5;
                cadete.EscudoActivo = !cadete.EscudoActivo;
                Console.WriteLine("✔ Estado del escudo alternado.");
            }
            else if (subOpcion == "2")
            {
                cadete.ModoSobrecarga = !cadete.ModoSobrecarga;
                if (cadete.ModoSobrecarga && cadete.NivelPeligro < 5) cadete.NivelPeligro++;
                Console.WriteLine("✔ Modo Sobrecarga alternado.");
            }
        }

        static void VerificarSituacionCritica()
        {
            if ((cadete.Estabilidad <= 20 || cadete.NivelPeligro >= 5) && conectado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠ ALERTA CRÍTICA: La estabilidad ha colapsado. Drenaje continuo activo.");
                cadete.Energia -= 5;
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (cadete.Energia <= 0 || cadete.Estabilidad <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n!!! COLAPSO VITAL DE LA INMERSIÓN !!!\nDesconexión de emergencia.");
                Console.ForegroundColor = ConsoleColor.Gray;
                conectado = false;
            }
        }

        static void VerificarNivelElite()
        {
            if (cadete.Energia < 25 && cadete.Estabilidad < 25 && cadete.NivelPeligro >= 4 && conectado)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n⭐ EVENTO ÉLITE: COLAPSO ESPACIO-TEMPORAL DETECTADO.");
                Console.WriteLine("El escudo se ha deshabilitado por sobrecarga.");
                cadete.EscudoActivo = false;
                cadete.Energia -= 5;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void DibujarEncabezado()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================================");
            Console.WriteLine("        SISTEMA DE SIMULACIÓN NEXUS v1.1         ");
            Console.WriteLine("=================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void DibujarPanelEstado()
        {
            DibujarEncabezado();
            Console.WriteLine($"EXPLORADOR: {cadete.Nombre.ToUpper()} | REALIDAD: {cadete.RealidadAsignada}");
            Console.WriteLine($"PELIGRO: Nivel {cadete.NivelPeligro}/5 | MAPEO: {cadete.SectoresExplorados}");
            Console.WriteLine($"ESCUDO: {(cadete.EscudoActivo ? "ACTIVO" : "INACTIVO")} | SOBRECARGA: {(cadete.ModoSobrecarga ? "ON" : "OFF")}");
            Console.WriteLine("-------------------------------------------------");
            Console.Write("ENERGÍA:    "); DibujarBarraProgreso(cadete.Energia);
            Console.Write("ESTABILIDAD:"); DibujarBarraProgreso(cadete.Estabilidad);
            Console.WriteLine("-------------------------------------------------");
        }

        static void DibujarBarraProgreso(int valor)
        {
            int bloques = valor / 10;
            Console.Write("[");
            if (valor > 50) Console.ForegroundColor = ConsoleColor.Green;
            else if (valor >= 25) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < 10; i++) Console.Write(i < bloques ? "█" : "░");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"] {valor}%");
        }

        static void MostrarAnimacionEscaneo(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(mensaje + " ");
            for (int i = 0; i < 4; i++) { Console.Write("■ "); Thread.Sleep(200); }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static int LeerEntero(string mensaje, int min, int max)
        {
            Console.Write(mensaje);
            int v;
            while (!int.TryParse(Console.ReadLine(), out v) || v < min || v > max)
                Console.Write($"[!] Ingrese número válido ({min}-{max}): ");
            return v;
        }
    }
}