# FacturaMarket - Sistema de Gestión y Facturación para Minimarket

Aplicación académica de escritorio para administrar ventas e inventario de un minimarket. El proyecto contiene el código fuente de Windows Forms, acceso a datos ADO.NET y un script de instalación de la base de datos.

## Arquitectura y tecnologías

- **Lenguaje:** C#.
- **Interfaz de escritorio:** Windows Forms.
- **Framework:** .NET Framework 4.7.2 (proyecto clásico de MSBuild).
- **Acceso a datos:** ADO.NET con `System.Data.SqlClient`.
- **Motor de base de datos:** Microsoft SQL Server.
- **Base de datos:** `MinisuperDB`.
- **Proyecto:** `ProyectoFacturaMarket\ProyectoFacturaMarket.csproj`.
- **Solución actualmente incluida:** `ProyectoFacturaMarket.slnx`.

Las responsabilidades se organizan en entidades (`Entidades`), acceso a datos (`Controlador`) y formularios (`Formulario`).

## Funcionalidad implementada

- Inicio de sesión y control de opciones de menú según el rol.
- Administración de categorías y productos, con desactivación lógica.
- Consulta de existencias por producto y categoría, con avisos visuales de stock bajo o agotado.
- Búsqueda de cliente y selección de Consumidor Final.
- Carrito de venta con comprobación de existencias antes de aceptar cantidades.
- Desglose tributario por productos con tarifa 0% y productos gravados con IVA del **15%**.
- Registro de cabecera y detalles de factura, y descuento de stock usando una transacción `SqlTransaction`.

## Requisitos previos

1. Windows con Visual Studio o Build Tools que incluyan MSBuild y targeting pack de .NET Framework 4.7.2.
2. SQL Server y SQL Server Management Studio (SSMS) para instalar y administrar la base de datos.
3. NuGet CLI para restaurar el paquete indicado en `ProyectoFacturaMarket\packages.config`.
4. Acceso a una instancia SQL Server local compatible con la cadena de conexión configurada en `Controlador\Conexion.cs` (`Data Source=.` y autenticación integrada de Windows), o ajustar esa configuración para el entorno local.

## Instalación de `MinisuperDB` con SSMS

1. Abra SQL Server Management Studio y conéctese a la instancia de SQL Server usando una cuenta con permisos para crear bases de datos.
2. En SSMS, seleccione **File > Open > File** y abra `ProyectoFacturaMarket\BaseDatos\MinisuperDB.sql`.
3. Revise el script. Crea `MinisuperDB` si aún no existe y crea las tablas que falten; también agrega datos semilla de categorías, productos, usuario administrador y Consumidor Final.
4. Ejecute el script con **Execute** (o F5). El script no elimina la base de datos ni tablas existentes.
5. En el Explorador de objetos, actualice **Databases** y confirme que aparece `MinisuperDB` con sus tablas.
6. Compruebe que la instancia, permisos y autenticación coincidan con la cadena de conexión usada por la aplicación.

> El script incluye un usuario académico/de prueba `admin` con clave `admin123`. La implementación actual valida la clave almacenada directamente; cambie estas credenciales en entornos de prueba compartidos y no use este esquema de contraseñas en producción.

## Compilación local

Desde la raíz del repositorio, en una consola de desarrollador de Visual Studio:

```powershell
nuget restore .\ProyectoFacturaMarket\packages.config -PackagesDirectory .\packages -NonInteractive
msbuild .\ProyectoFacturaMarket.slnx -m -p:Configuration=Release -p:Platform="Any CPU"
```

El flujo de GitHub Actions ejecuta los mismos pasos de restauración y compilación en un runner Windows para cada `push` y `pull_request` dirigido a `main` o `develop`. La integración continua verifica la compilación; no inicia SQL Server ni ejecuta pruebas de integración contra la base de datos.

### Nota sobre el archivo de solución

En la copia actual de la solución el archivo es `ProyectoFacturaMarket.slnx`; no se encontró un archivo `.sln` clásico. Por eso, el pipeline de esta etapa compila el `.slnx` real con MSBuild y restaura el `packages.config` del proyecto. Si se incorpora posteriormente una solución `.sln` clásica, habrá que actualizar los comandos del workflow para usar su ruta.

## Flujo de trabajo GitFlow

- `main`: versiones estables y entregables.
- `develop`: integración del trabajo terminado que se prepara para la siguiente versión.
- `feature/<tema>`: ramas de trabajo creadas desde `develop`, por ejemplo `feature/inventario-alertas`.

Flujo recomendado:

1. Crear una rama de característica desde `develop`.
2. Implementar y probar el cambio; guardar commits pequeños con mensajes descriptivos.
3. Publicar la rama y abrir un Pull Request hacia `develop`.
4. Revisar que el pipeline de CI finalice correctamente y atender los cambios solicitados.
5. Integrar las características aprobadas en `develop`.
6. Al preparar una entrega, abrir un Pull Request de `develop` hacia `main`.

## Primer commit y publicación en GitHub

La carpeta de trabajo debe estar inicializada como repositorio Git y Git debe estar instalado. Sustituya la URL de ejemplo por la dirección HTTPS o SSH del repositorio creado en GitHub.

```powershell
git init
git branch -M main
git add .
git commit -m "Initial FacturaMarket application"
git remote add origin https://github.com/USUARIO/REPOSITORIO.git
git push -u origin main
```

Después, cree `develop` y publíquela:

```powershell
git switch -c develop
git push -u origin develop
```

Para el trabajo siguiente, cree una rama desde `develop`, por ejemplo `git switch -c feature/nombre-del-cambio`, y envíela con `git push -u origin feature/nombre-del-cambio` antes de abrir un Pull Request.
