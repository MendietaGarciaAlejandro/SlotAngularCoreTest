# Slot Casino - Core Test

Bienvenido al repositorio de **Slot Casino**. Este proyecto es una prueba de concepto para simular una plataforma de juegos de casino online, enfocada en la experiencia de usuario y una arquitectura robusta.

La idea es construir un sistema escalable y moderno, separando claramente las responsabilidades entre el cliente, el servidor y los datos.

## 🏗️ Arquitectura del Proyecto

El sistema está dividido en tres pilares principales:

*   **Frontend (Angular):**
    Toda la interfaz de usuario está desarrollada con Angular. He buscado darle un toque "premium" (temas oscuros, dorados, neón) para que se sienta como un casino real. Aquí es donde vive la lógica de presentación y la interacción con el jugador.

*   **Backend (ASP.NET Core API):**
    *(En desarrollo)* El cerebro de la operación. Esta API se encarga de gestionar la lógica de negocio, validar las jugadas y mantener la seguridad de las transacciones. 

*   **Base de Datos (Supabase):**
    *(En desarrollo)* Usamos Supabase para la persistencia de datos. Aquí guardaremos perfiles de usuarios, historiales de partidas y configuraciones.

## 🚀 Cómo empezar

De momento, puedes arrancar la parte visual (Frontend) para ver cómo luce:

1.  Entra a la carpeta del frontend:
    ```bash
    cd frontend
    ```
2.  Instala las dependencias:
    ```bash
    npm install
    ```
3.  Arranca el servidor de desarrollo:
    ```bash
    npm start
    ```

¡Y listo! Deberías ver la aplicación corriendo en `http://localhost:4200`.

---
*Este proyecto está en evolución constante. Si ves algo que se pueda mejorar, ¡toda sugerencia es bienvenida!*
