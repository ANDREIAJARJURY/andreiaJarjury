# Arquitectura Propuesta (WinForms + SQL Server)

Implementaremos una Arquitectura en 3 Capas (3-Tier Architecture).

## Estructura de Capas
1. **Capa de Presentación (UI - Windows Forms):** Formularios (`.cs` y `.Designer.cs`). Captura los clics y actualiza ProgressBars y Labels.
2. **Capa de Negocio (BLL - Lógica del Juego):** Clases actuales migradas (`Personaje`, `Cadete`, `Inventario`). Procesan matemáticas y reglas.
3. **Capa de Acceso a Datos (DAL):** Conexión (`SqlConnection`) y comandos hacia SQL Server.

## Diagrama de Arquitectura
[ Windows Forms UI ] <--> [ Controladores / Lógica de NEXUS ] <--> [ Repositorio DAL ] <--> [ SQL Server DB ]
