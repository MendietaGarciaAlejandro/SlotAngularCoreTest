# 🎰 Slot Casino - Core Test

Bienvenido al repositorio de **Slot Casino**. Este proyecto es una prueba de concepto para una plataforma de juegos de casino online, enfocada en una arquitectura moderna y una experiencia de usuario premium.

## 📊 Estado Actual del Proyecto

*   **Frontend:** ~20% completado. (Lobby funcional, Juego Play, Mock Services).
*   **Backend:** ~10% completado. (Migración a .NET 10, Controladores Mock base, Rest API).
*   **Base de Datos:** ~10% completado. (Diseño lógico UML, Esquema SQL PostgreSQL).

## 🏗️ Arquitectura y Avances

### 🎮 Frontend (Angular v17+) - **[20%]**
La interfaz está diseñada con una estética oscura y dorada para una sensación premium.
- **Home**: Banner y juegos destacados.
- **Lobby (v2.2)**: Sistema de navegación reactivo y listado completo de juegos.
- **Game Play**: Lógica real de slot machine (giros, cuadrícula dinámica, detección de premios).
- **Core**: Servicios optimizados para una carga instantánea y manejo de estados.

### ⚙️ Backend (ASP.NET Core 10.0) - **[10%]**
*Migrado recientemente desde .NET 8.0 para aprovechar las mejoras de rendimiento y seguridad.*
Diseñado para ser robusto y compatible con Visual Studio.
- **Solución VS**: Estructura organizada en `src/` preparada para escalado.
- **Modelos**: Reflejo inicial de las entidades del juego (`Game`, `GameConfig`).
- **RESTful API**: 11 Endpoints iniciales (`GamesController`) para catálogo, búsquedas y filtros de juegos (usando *Mock Data* temporal).
- **CORS & OpenAPI**: Swagger y CORS configurados para integración directa con el frontend.

**Análisis de Completitud para 100%:**
Para lograr una API funcional de casino puro, es necesario implementar:
1. **Integración DB (~20%)**: EF Core + PostgreSQL (Supabase) para persistir datos.
2. **Auth & Perfiles (~20%)**: Autenticación JWT y roles (Usuario/Admin).
3. **Wallet/Transacciones (~25%)**: Motor seguro de balance, depósitos y retiros.
4. **Game Logic Engine (~25%)**: Generación de números aleatorios (RNG) segura en el backend y resolución matemática de las tiradas para evitar manipulaciones en el frontend.

### 🗄️ Base de Datos (Supabase / PostgreSQL) - **[10%]**
Infraestructura inicial y diseño relacional completo.
- **Esquema UML**: Diagrama de clases detallado en [database_uml.md](file:///home/user0000/Documentos/SlotAngularCoreTest/infra/supabase/database_uml.md).
- **Script SQL**: Definición de tablas (`perfiles`, `juegos`, `transacciones`) en [schema_inicial.sql](file:///home/user0000/Documentos/SlotAngularCoreTest/infra/supabase/schema_inicial.sql).
- **RLS**: Bases preparadas para seguridad de nivel de fila.

## 🚀 Cómo empezar

### Frontend
1. Entra a `frontend/` e instala: `npm install`
2. Arranca: `npm start`
3. Abre: `http://localhost:4200`

### Backend (Visual Studio / .NET CLI)
1. Abre `backend/SlotCasino.sln` en **Visual Studio**.
2. O usa la CLI: `dotnet run --project backend/src/SlotCasino.Api/SlotCasino.Api.csproj`
3. Explora la API en: `http://localhost:5000/swagger`

---
*Este proyecto está en evolución constante. v2.2 del frontend y v0.1 del backend.*

