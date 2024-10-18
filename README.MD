# Aplicación de Windows Forms

## Descripción

Esta es una aplicación de Windows Forms desarrollada en C# que gestiona eventos y entradas de usuario, para un centro de acopio municipal. Permite la manipulación eficiente de datos y la interacción con el usuario a través de una interfaz gráfica amigable.

### Vistas y roles


Existe una pantalla para iniciar sesion, o salir.

Se cuentan con dos roles, admin y operador.
Para efectos practicos, las cuentas son:

Admin

admin, admin123

Operador

operator, operator123

El administrador sera capaz de agregar solicitudes, recursos y donaciones a las tablas del centro.

El operador sera capaz de modificar y eliminar, ademas de generar reportes. El administador tambien podra hacer todo esto.

Se cuenta con 3 tablas, 1 para cada elemento respectivamente. Estas se actualizan en tiempo real, incluyendo al formulario 
para añadir elementos.

El administrador tendra la posibilidad de ver la tabla de todos los eventos realizados, con un refresh manual, permitiendo mejor
optimizacion al hacer menos queries solo cuando se necesite.

Se pueden generar reportes de donaciones, recursos y solicitudes.

El sistema de notificaciones informara al usuario de cada accion realizada.

En las tablas, se puede filtrar por diferentes campos, usando los textbox y el boton para aplicar/limpiar el filtro.
Tambien existe la opcion de busqueda por algunos de los campos de las tablas, relevantes para la busqueda de texto.

Por ultimo, existe un pequeño menu para salir o ver otra vista con los integrantes y carnets de los integrantes del equipo


## Requisitos

- .NET Framework 4.7.2 o superior
- Visual Studio 2019 o superior

## Instalación

Recuerda que debes tener corriendo SQL en la direccion especificada (para ver mas, puedes ver cualquier view con queries, ejemplo, login). Si no, obtendras una notificacion con el error.

   ```bash
   git clone https://github.com/EduardoDevOlmedo/labo-eventos
   cd labo-eventos
   dotnet restore
   dotnet build
   dotnet run
   ````


