# Análisis Técnico y Toma de Decisiones

## 1. Interfaz Gráfica
* **Decisión:** **Windows Forms**. 
* **Justificación:** Transición suave desde consola y cumple con los requerimientos del proyecto.

## 2. Persistencia
* **Decisión:** **Microsoft SQL Server**.
* **Justificación:** Restricción obligatoria del proyecto. Garantiza integridad relacional. Se usará ADO.NET (`System.Data.SqlClient`) por su ligereza.

## 3. Mantenibilidad
El acoplamiento actual de `Console.WriteLine` se resolverá devolviendo `strings` desde la capa de Negocio hacia WinForms, asegurando que la UI solo dibuje datos.
