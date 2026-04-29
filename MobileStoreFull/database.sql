-- ============================================
-- Mobile Info Store — Database Setup
-- Run this in MySQL before starting the app
-- ============================================

CREATE DATABASE IF NOT EXISTS mobilestore;
USE mobilestore;

CREATE TABLE IF NOT EXISTS Mobile (
    id        INT AUTO_INCREMENT PRIMARY KEY,
    brand     VARCHAR(100)   NOT NULL,
    model     VARCHAR(150)   NOT NULL,
    price     DECIMAL(10,2)  NOT NULL,
    focus     VARCHAR(50)    NOT NULL,   -- e.g. Gaming, Photography, General
    ram_gb    INT            NOT NULL DEFAULT 4,
    storage_gb INT           NOT NULL DEFAULT 64,
    created_at DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Sample data
INSERT INTO Mobile (brand, model, price, focus, ram_gb, storage_gb) VALUES
('Samsung', 'Galaxy S24 Ultra',   129999.00, 'Photography', 12, 256),
('Apple',   'iPhone 15 Pro Max',  159900.00, 'Photography',  8, 256),
('ASUS',    'ROG Phone 8 Pro',    109999.00, 'Gaming',       16, 512),
('OnePlus', 'OnePlus 12',          64999.00, 'General',      12, 256),
('Xiaomi',  'Redmi Note 13 Pro',   26999.00, 'Photography',   8, 256);
