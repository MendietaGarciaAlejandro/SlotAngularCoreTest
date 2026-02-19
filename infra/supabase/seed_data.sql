-- Limpiar tablas por si acaso (Opcional, ten cuidado en prod)
-- DELETE FROM transacciones;
-- DELETE FROM config_juegos;
-- DELETE FROM juegos;
-- DELETE FROM perfiles;

-- 1. Insertar primero en Auth de Supabase para evitar Error 23503 (Foreign Key constraint a auth.users)
-- Supabase gestiona sus IDs de usuario independientemente, inyectaremos un usuario demo
INSERT INTO auth.users (id, aud, role, email, encrypted_password, email_confirmed_at, created_at, updated_at)
VALUES 
    ('11111111-1111-1111-1111-111111111111', 'authenticated', 'authenticated', 'demo@casino.local', 'fake_password_hash', NOW(), NOW(), NOW())
ON CONFLICT (id) DO NOTHING;

-- 2. Insertar Perfil de Prueba
INSERT INTO perfiles (id, nombre_usuario, saldo, creado_en, actualizado_en)
VALUES 
    ('11111111-1111-1111-1111-111111111111', 'jugador_demo', 5000.00, NOW(), NOW())
ON CONFLICT (id) DO NOTHING;

-- 2. Insertar Juegos (Slots)
INSERT INTO juegos (id, titulo, proveedor, url_miniatura, rtp, volatilidad, es_destacado, descripcion, creado_en)
VALUES 
    ('22222222-2222-2222-2222-222222222222', 'Piratas del Caribe Slot', 'NetEnt', 'https://images.unsplash.com/photo-1518599904199-0ca897819ddb?auto=format&fit=crop&q=80&w=400', 96.50, 'Alta', true, 'Aventura pirata de alta volatilidad', NOW()),
    ('33333333-3333-3333-3333-333333333333', 'Frutas Clásicas 777', 'Pragmatic Play', 'https://images.unsplash.com/photo-1596838132731-3301c3fd4317?auto=format&fit=crop&q=80&w=400', 98.00, 'Baja', true, 'El clásico de las frutas 3x3', NOW()),
    ('44444444-4444-4444-4444-444444444444', 'Leyendas de Egipto', 'PlayNGo', 'https://images.unsplash.com/photo-1502481851512-e9e2529bfbf9?auto=format&fit=crop&q=80&w=400', 95.80, 'Media', false, 'Descubre los tesoros del faraón', NOW())
ON CONFLICT (id) DO NOTHING;

-- 3. Insertar Configuración de los Juegos (Tableros y Símbolos)
INSERT INTO config_juegos (id, id_juego, filas, columnas, lineas_pago, color_tema, simbolos, actualizado_en)
VALUES
    -- Piratas: 5x3, Alta volatilidad, tema oscuro naval
    ('55555555-5555-5555-5555-555555555555', '22222222-2222-2222-2222-222222222222', 3, 5, 25, '#0a192f', ARRAY['☠️', '⚔️', '💣', '⚓', '💎', '🦜', '💰'], NOW()),
    
    -- Frutas 777: 3x3 clásico, colores vibrantes
    ('66666666-6666-6666-6666-666666666666', '33333333-3333-3333-3333-333333333333', 3, 3, 5, '#8b0000', ARRAY['🍒', '🍋', '🍉', '🍇', '🔔', '7️⃣'], NOW()),
    
    -- Egipto: 5x4 grande, dorado
    ('77777777-7777-7777-7777-777777777777', '44444444-4444-4444-4444-444444444444', 4, 5, 40, '#b8860b', ARRAY['⚱️', '🐫', '👁️', '🪲', '🏺', '👑', '📜'], NOW());
