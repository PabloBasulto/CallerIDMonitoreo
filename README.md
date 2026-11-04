
# Identificador de la llamadas para la central de monitoreo

## 1. Objetivo del proyecto
En la central de monitoreo de la empresa, los monitoristas son responsables de procesar, analizar y atender los eventos de alarma (disparos) recibidos. Asimismo, desempeñan funciones de atención al cliente mediante la recepción y gestión de llamadas relacionadas con dudas sobre los servicios, solicitudes de mantenimiento y problemas con los sistemas de alarma, entre otros asuntos.

Una de las dificultades que se presenta durante este proceso ocurre cuando un cliente solicita asistencia por algún problema relacionado con su equipo y/o con la señal del mimsmo. En estos casos, el monitorista necesita consultar la información de la cuenta correspondiente; sin embargo, con frecuencia, el cliente desconoce o no proporciona de manera incorrecta los datos necesarios para identificar dicha cuenta. Esto ocasiona retrasos en el proceso de atención, lo cual puede llegar a impactar de manera directa en la  resolución del problemay generar inconformidad en el cliente.

Por lo anterior, este proyecto surge como una herramienta destinada a agilizar el proceso de identificación de cuentas durante la recepción de llamadas, facilitando el acceso a la información del cliente y permitiendo brindar una atención más eficiente y oportuna.

# 2. Estructura y organización del proyecto
El proyecto está desarrollado en un framework .net maui 8 una marco de trabajo destinado al desarrollo de aplicaciones nativas multiplataforma de escritorio mediante el lenguaje C# y XAML utilizando un patrón arquitectura de tipo MVVM (Modelo -Vista- ModeloVista). Con los componentes.

## Componentes arquitectura MVVM
**Modelo (Model)**: Representa los datos de la aplicación y la lógica de negocio o de acceso a datos (bases de datos, repositorios, APIs). No tiene conocimiento de la interfaz de usuario

**Vista**: Es la interfaz gráfica (como elementos visuales, XML o XAML) que ve el usuario. Muestra los datos y captura las interacciones del usuario, pero no contiene lógica de negocio.

**Modelo Vista(MainPageModel.cs)**: Actúa como intermediario entre el Modelo y la Vista. Mantiene el estado de la vista, expone propiedades observables y gestiona los comandos o eventos generados en la interfaz.



### 2.1. Carpeta Models


#### 2.1.1. Clase [Cuenta.cs]
Representa la clase de la cuenta que se extrae de la base de datos recuperando información el número del teléfono, id de uenta y el nombre de la cuenta 

#### 2.1.2. Clase [DBService.cs]
Como su nombre lo indica es una clase con las funciones necesarias para realizar todo tipo de interacción de manera directa con la base de datos remota. Su funciones principales son las de establecer una conexión con la BD así como la realizar la búsqueda de la cuenta mediante el número telefónico detectado.


#### 2.1.3. Clase [DetectLlamada.cs]
Clase encargada de operar el mecanismo de detección de llamadas( próximo a implementar), así como un mecaniso para validar y notificar al MainPageViewModel de que una llamada está entrando para activar los mecanismos de conexión y búsqueda

#### 2.1.4. Clase [Llamada.cs]
Clase generada con el atributo de llamada y con el cual se realizará la búsqueda en en la BD mediante su atributo Llamada.Numero

#### 2.1.5. Clase [IEvento.cs]
Interfaz de abstracción que sirve para generar el evento en el [DetectLlamada.cs]

## 2.1.6 Clase [MainPageViewModel.cs]
Clase que desempeña el papel del componente Modelo Vista en la arquitectura del programa. Realiza el flujo principal del funcionamiento del programa en la cual las clases interactúan entre sí para el hilo principal. Desde la conexión a la BD, escuchar una llamada, extraer información, búsqueda etc...

## 3. Archivos principales de la aplicación

### 3.1. App.xaml

### 3.2. App.xaml.cs

### 3.3. AppShell.xaml

### 3.4. AppShell.xaml.cs

## 4. Interfaz principal: MainPage

### 4.1. MainPage.xaml

### 4.2. MainPage.xaml.cs

## 5. Arquitectura y flujo de ejecución

## 6. Estado actual del desarrollo

## 7. Próximas implementaciones
