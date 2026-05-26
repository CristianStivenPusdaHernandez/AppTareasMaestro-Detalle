# App Tareas - Estructura Maestro/Detalle

Aplicación móvil desarrollada con el framework **.NET MAUI** utilizando el patrón de persistencia de datos relacional local. El sistema simula un entorno dinámico para la organización de grupos de trabajo y sus tareas asignadas.

## 🚀 Requerimientos Cumplidos
- **Persistencia con SQLite:** Implementación del motor local a través del ORM `sqlite-net-pcl`.
- **Relación de Tablas:** Base de datos estructurada en una relación relacional **Maestro (Categorías)** y **Detalle (Tareas)** con integridad referencial.

---

## Evidencia de la Aplicación en Ejecución

A continuación se adjuntan las capturas del correcto despliegue del proyecto en el emulador Android:

### 1. Gestión de Categorías (Maestro)
Interfaz principal que lista las categorías creadas. El botón "Editar" permite cambiar el estado del formulario superior a modo de actualización cargando los datos de forma automática.

<img width="278" height="646" alt="Categorias" src="https://github.com/user-attachments/assets/abd759a0-3b37-47df-892a-30524b2a99ff" />


### 2. Gestión de Tareas (Detalle)
Pantalla secundaria que recupera el identificador de la categoría seleccionada y despliega su listado de tareas pendientes o completadas.

<img width="278" height="646" alt="TareasCategoria" src="https://github.com/user-attachments/assets/4cd3226b-a0d2-4e8d-9691-4266dbc399fe" />

### 3. Gestión de Tareas Globales
Pantalla que muestra todas las tareas de todas las categorías de forma global.

<img width="278" height="646" alt="Tareas-Globales" src="https://github.com/user-attachments/assets/c27898f8-b67b-4393-903d-039a3ff6735f" />

---

## 🛠️ Stack Tecnológico
- **Framework:** .NET MAUI
- **Base de Datos:** SQLite
- **Lenguaje de Programación:** C# / XAML
- **Entorno de Desarrollo:** Visual Studio
