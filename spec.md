# Especificación del proyecto: FacturaMarket

## 1. Objetivo y Contexto de la Problemática
Desarrollar una solución tecnológica en C# con Windows Forms y SQL Server para la automatización de ventas, control de inventario en tiempo real y gestión de facturación en minimarkets de la ciudad de Machala, eliminando registros manuales, errores en cálculos tributarios y quiebres de stock[cite: 3].

## 2. Funcionalidades y Módulos Principales
- **Módulo de Autenticación y Seguridad:** Control de acceso basado en roles (Administrador y Cajero) validados contra la base de datos de usuarios[cite: 3].
- **Gestión de Clientes:** Administración de perfiles por cédula y tipo de identificación, con búsquedas en tiempo real y registro directo desde el flujo de venta[cite: 3].
- **Control de Inventario y Catálogos:** Gestión de categorías y productos con precios, indicador de afectación de IVA y control de existencias mínimas[cite: 3].
- **Ventas y Facturación:** Pantalla principal de punto de ventas (POS) que calcula de forma dinámica subtotales, IVA y totales a pagar con redondeo, aplicando transacciones atómicas (`SqlTransaction`)[cite: 3].

## 3. Requerimientos Tributarios (SRI)
- Discriminación automatizada de tarifas impositivas: Tarifa 0% para productos de la canasta básica y tarifa vigente (15%) para productos gravados[cite: 3].
- Preparación estructural para la integración futura de comprobantes electrónicos con los entes de control tributario[cite: 3].

## 4. Entidades Principales (Modelo Relacional)
- `Categoria`
- `Producto`
- `Cliente`
- `Usuario`
- `Factura`
- `DetalleFactura`
- `ControlFactura`

## 5. Tecnología y Arquitectura
- **Lenguaje y Entorno:** C# (.NET) con interfaz en Windows Forms.
- **Arquitectura:** Patrón en Capas (Dominio, Aplicación, Infraestructura y Presentación)[cite: 3].
- **Persistencia:** SQL Server / LocalDB (`(localdb)\MSSQLLocalDB`) utilizando ADO.NET[cite: 3].
- **Control de Versiones y DevOps:** Git bajo el flujo **GitFlow**, GitHub para el alojamiento remoto, y **GitHub Actions** para pipelines de integración continua (CI)[cite: 3].
- **Calidad de Software:** Pruebas unitarias implementadas con **xUnit** para verificar reglas de negocio y consistencia[cite: 3].

## 6. Gestión del Proyecto y Seguimiento
- **Issues:** Registro y seguimiento estructurado mediante etiquetas normalizadas (`[FEAT]`, `[BUG]`, `[DOCS]`) vinculadas a criterios de aceptación[cite: 3].
- **Projects:** Tablero Kanban para planificar y organizar visualmente las tareas en curso, pendientes y completadas[cite: 3].
- **Milestones (Hitos):** 
  - *Milestone 1:* Infraestructura, configuración de GitFlow, entidades de dominio y pipeline básico en GitHub Actions[cite: 3].
  - *Milestone 2:* Formularios de facturación, cálculo impositivo, pruebas unitarias y documentación final[cite: 3].

## 7. Criterios de Aceptación
- La aplicación compila correctamente y el pipeline de GitHub Actions valida automáticamente la ausencia de errores sintácticos en cada actualización[cite: 3].
- Las transacciones de venta garantizan atomicidad mediante `SqlTransaction`, asegurando que la rebaja de inventario y el registro de la factura ocurran de manera unificada[cite: 3].
- Se aplican restricciones `CHECK` a nivel de base de datos para impedir existencias negativas o precios menores a cero[cite: 3].
