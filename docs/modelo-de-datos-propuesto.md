# Modelo de Datos Propuesto (SQL Server)

Se creará una base de datos relacional `NexusDB`.

## Entidades y Tablas Principales
1. **Tabla: `Partidas`**
   * `IdPartida` (INT, PK)
   * `NombreJugador` (VARCHAR)
   * `Nivel` (INT)
   * `Experiencia` (INT)
   * `EnergiaActual` (INT)

2. **Tabla: `Inventario`**
   * `IdItem` (INT, PK)
   * `IdPartida` (INT, FK)
   * `NombreItem` (VARCHAR)
   * `Cantidad` (INT)

## Estrategia de Persistencia
* **Guardar:** `INSERT`/`UPDATE` en `Partidas` desde la capa DAL.
* **Cargar:** `SELECT` por `IdPartida`, instanciando el objeto `Cadete` con los valores recuperados.
