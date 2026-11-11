# Diseño del Juego: NEXUS

## Visión del juego
NEXUS ofrecerá una experiencia RPG de gestión de recursos y toma de decisiones tácticas. El jugador asumirá el rol de un Cadete espacial que debe explorar sectores desconocidos, enfrentando anomalías y enemigos. La motivación principal será subir de nivel (XP), recolectar recursos raros y sobrevivir el mayor tiempo posible gestionando su energía y el inventario.

## Ciclo principal de juego
1. **Base / Menú:** El jugador revisa su estado, inventario y selecciona un sector a explorar.
2. **Exploración:** Al avanzar, el sistema genera eventos (encontrar un enemigo, chocar con un asteroide o hallar un botín).
3. **Decisión Táctica:** El jugador elige: *Atacar*, *Escapar* o *Analizar*.
4. **Resolución:** Se actualizan las estadísticas (se gasta energía, se gana XP, se recogen ítems).

## Mecánicas y reglas
* **Personajes:** Basado en la clase abstracta `Personaje`.
* **Inventario Dinámico:** Uso de mochila para almacenar recursos. Usar un ítem lo consume y restaura atributos.
* **Energía y Estabilidad:** Limitados de 0 a 100. Si la energía llega a 0, Game Over.

## Experiencia de usuario (UX)
* **Jerarquía visual:** La vida y la energía siempre estarán visibles en la parte superior.
* **Legibilidad:** Uso de tipografías monospace para dar sensación de terminal espacial.
