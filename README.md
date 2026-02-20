# 🎰 Slot Casino - Core Test

Bienvenido al repositorio de **Slot Casino**. Este proyecto es una prueba de concepto para una plataforma de juegos de casino online, enfocada en una arquitectura moderna y una experiencia de usuario premium.

## 📊 Estado Actual del Proyecto

*   **Frontend:** ~40% completado. (Lobby real conectado, Integración con API, Game Play dinámico).
*   **Backend:** ~60% completado. (Supabase SDK Integration, Wallet Service, RNG Motor).
*   **Base de Datos:** ~50% completado. (Esquema real en Supabase, Datos de prueba/Seed).

## 🏗️ Arquitectura y Avances

### 🎮 Frontend (Angular v17+) - **[40%]**
La interfaz está diseñada con una estética oscura y dorada para una sensación premium.
- **Home**: Banner y acceso a lobby.
- **Lobby**: Listado dinámico consumiendo datos desde la API real de ASP.NET Core.
- **Game Play**: Lógica de slot machine conectada al backend (apuestas y premios reales).
- **Core**: Servicios integrados con la API mediante `HttpClient`.

### ⚙️ Backend (ASP.NET Core 10.0) - **[60%]**
*Migrado recientemente para usar el SDK oficial de Supabase C#, eliminando dependencias de EF Core para mayor estabilidad.*
- **Supabase SDK**: Conexión HTTPS robusta (vía Rest/Postgrest) que soluciona problemas de conectividad IPv6 de PostgreSQL directo.
- **Servicios**:
  - `MotorJuego`: Lógica de RNG y cálculo de premios en el lado del servidor.
  - `ServicioBilletera`: Gestión de transacciones y saldos persistidos en DB.
- **DTOs & Serialización**: Implementación de DTOs atómicos y `Newtonsoft.Json` para una salida de datos limpia y sin metadatos internos del SDK.
- **CORS & OpenAPI**: Swagger configurado para pruebas directas en `http://localhost:5000/swagger`.

### 🗄️ Base de Datos (Supabase / PostgreSQL) - **[50%]**
Infraestructura real operativa en la nube con Supabase.
- **Esquema Real**: Tablas `perfiles`, `juegos`, `config_juegos` y `transacciones`.
- **Seed Data**: Script `seed_data.sql` disponible para inicializar el entorno de pruebas.

## 🚀 Cómo empezar

### 1. Requisitos
- .NET 10.0 SDK
- Node.js & Angular CLI
- Cuenta de Supabase

### 2. Configuración de API (Backend)
Debes configurar las credenciales de Supabase en tu entorno local usando `user-secrets`:
```bash
cd backend/src/SlotCasino.Api
dotnet user-secrets set "Supabase:Url" "TU_PROJECT_URL"
dotnet user-secrets set "Supabase:Key" "TU_ANON_KEY"
dotnet run
```

### 3. Frontend
```bash
cd frontend
npm install
npm start
```
Abre: `http://localhost:4200`

---
*v2.5 del proyecto. Backend estabilizado con Supabase Client SDK.*

