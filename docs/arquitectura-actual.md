# Arquitectura Actual (NEXUS H3)

El proyecto actual funciona bajo POO en una aplicación de consola monolítica.

## Clases y Funcionalidades Actuales
* **`Personaje`:** Define atributos base y el método virtual `Encontrarse()`.
* **Clases Derivadas:** `Cadete`, `Robot` y `Enemigo`.
* **Sistema de Inventario:** Utiliza `List<Item>` para permitir recolección de objetos.
* **Eventos Aleatorios:** Implementados con la clase `Random`.
* **Excepciones:** Controles con `try-catch` e `int.TryParse`.

## Limitaciones Reales
1. Ausencia de persistencia (al cerrar, se pierde el progreso).
2. Interfaz limitada (texto en consola negra).
3. Acoplamiento de la lógica con `Console.WriteLine`.
