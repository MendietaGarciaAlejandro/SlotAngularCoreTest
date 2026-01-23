-- Script de Creación de Base de Datos para Supabase (PostgreSQL)

-- 1. Tabla de Perfiles (Extensión de auth.users)
CREATE TABLE public.perfiles (
    id UUID PRIMARY KEY REFERENCES auth.users(id) ON DELETE CASCADE,
    nombre_usuario TEXT UNIQUE,
    saldo NUMERIC(15, 2) DEFAULT 1000.00,
    creado_en TIMESTAMPTZ DEFAULT NOW(),
    actualizado_en TIMESTAMPTZ DEFAULT NOW()
);

-- 2. Tabla de Juegos (Catálogo)
CREATE TABLE public.juegos (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    titulo TEXT NOT NULL,
    proveedor TEXT NOT NULL,
    url_miniatura TEXT,
    rtp NUMERIC(5, 2),
    volatilidad TEXT CHECK (volatilidad IN ('Alta', 'Media', 'Baja')),
    es_destacado BOOLEAN DEFAULT FALSE,
    descripcion TEXT,
    creado_en TIMESTAMPTZ DEFAULT NOW()
);

-- 3. Tabla de Configuración de Juegos (1:1 con Juegos)
CREATE TABLE public.config_juegos (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    id_juego UUID NOT NULL UNIQUE REFERENCES public.juegos(id) ON DELETE CASCADE,
    filas INTEGER NOT NULL,
    columnas INTEGER NOT NULL,
    lineas_pago INTEGER DEFAULT 0,
    color_tema TEXT DEFAULT '#444444',
    simbolos TEXT[] NOT NULL, -- Array de texto de PostgreSQL
    actualizado_en TIMESTAMPTZ DEFAULT NOW()
);

-- 4. Tabla de Transacciones (Historial)
CREATE TABLE public.transacciones (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    id_perfil UUID NOT NULL REFERENCES public.perfiles(id),
    id_juego UUID REFERENCES public.juegos(id),
    tipo TEXT NOT NULL CHECK (tipo IN ('apuesta', 'premio', 'deposito', 'retiro')),
    monto NUMERIC(15, 2) NOT NULL,
    saldo_despues NUMERIC(15, 2) NOT NULL,
    creado_en TIMESTAMPTZ DEFAULT NOW()
);

-- Habilitar Row Level Security (RLS) básico
ALTER TABLE public.perfiles ENABLE ROW LEVEL SECURITY;
ALTER TABLE public.transacciones ENABLE ROW LEVEL SECURITY;

-- Nota: Deberás configurar las políticas (Policies) de Supabase 
-- para permitir que los usuarios vean/editen sus propios datos.
