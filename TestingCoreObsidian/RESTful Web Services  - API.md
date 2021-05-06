# RESTful Web Services  - API
### Vidly, curso ASPNET MVC 5 y Web API
<hr>

## Objetivo y descripción introductoria

<hr>

<p class="justify">
 <strong>El objetivo principal era crear una aplicación que cumpliera con una arquitectura RESTful Web API</strong>, incluyendo las funcionalidades principales de la misma.
</p>

<p class="justify">
 Sin embargo, <strong>noté que la implementación se estaba llevando en un entorno de desarrollo utilizando .NET Framework</strong>, y por la diferencia de versiones, algunas sentencias, estructuras, librerías o funciones ya no cumplían o se encuentran descontinuadas, <strong>por lo que decidí continuar con la implementación de la aplicación del curso utilizando .NET Core</strong> .
</p>

<p class="justify">
 El repositorio en cuestión, se encuentra creado, acondicionado y configurado en una arquitectura <strong>ASP.NET Core Web API</strong>.
</p>

<p class="justify">
 De igual manera, este repositorio tiene como fin principal, demostrar el funcionamiento de las operaciones básicas de un servicio web REST, aún no se ha añadido funcionalidad más compleja a la aplicación.
</p>

## Aspectos, conceptos y conocimientos aplicados

<hr>

<p class="justify">
 Debido a que la implementación fue realizada en ASP.NET Core, se realizaron algunos ajustes:
</p>

#### Dependency Injection

<p class="justify">
Algunos paquetes, librerías, namespaces y configuraciónes fueron configuradas dentro del Startup.cs de la siguiente manera:
</p>

##### Configure Services
![[ConfigureServices.png]]

##### Configure
![[Configure.png]]

#### Controllers
<p class="justify">
Debido a que en esta plantilla o arquitectura de trabajo no se cuenta con vistas o está directamente configurada para funcionar como WebAPI, .NET Core hace más sencillo adaptar las rutas y la declaración de ApiControllers:
</p>

![[Controllers.png]]

##### ActionResults

<p class="justify">
De igual forma y gracias al curso, he implementado las convenciones que mejor se adapten a una aplicación tipo RESTful, mandando los resultados correspondientes:
</p>

![[ActionResults.png]]

<p class="justify">
<strong>Siendo sincero y de manera muy personal, yo acostumbraba más a utilizar respuestas tipo JsonResult en la mayoría de mis respuestas</strong>, debido a que se me hacía más facil adaptar las respuestas para los clientes de esta forma. Pero entiendo que, <strong>al utilizar una WebAPI como medio de consumo para N cantidad y variedad de clientes, tiene que estar lo mejor adaptada para distintos escenarios.</strong> 
</p>

##  Funcionalidad

<hr>

<p class="justify">
 El proyecto contiene una funcionalidad basada en RESTful Web Services / API, por lo que se encarga de manejar todas las peticiones recibidas por los clientes, utilizando el protocolo HTTP como parte principal y sus métodos, los cuales son:
</p>

| Método | Función                                                                               |
| ------ | ------------------------------------------------------------------------------------- |
| GET    | Obtener, consultar, o leer información/recursos                                       |
| POST   | Envíar datos, información o recursos (normalmente para insertar datos en el servidor) |
| PUT    | Actualizar algún recurso del lado del servidor                                        |
| DELETE | Eliminar/remover algún recurso u objeto del servidor                                  |

<p class="justify">
Derivado de esto, la aplicación contiene las funciones para consultar, insertar, actualizar y eliminar registros que estén en una base de datos, siendo o actuando en su mayoría como un CRUD.
</p>

## Pruebas
<hr>

<p class="justify">
 Las funcionalidades de esta aplicación han sido probadas en primera instancia utilizando la herramienta <strong>Postman</strong> para el manejo de solicitudes a los servicios y evaluación de las respuestas.
</p>

#### CustomersController
- GET Customers (api/customers)
![[GET Customers.png]]
- GET Customer (api/customers/Id)
![[GET Customer.png]]
- POST Customer (api/customer)
![[POST Customer.png]]
- PUT Customer (api/customer/Id)
![[PUT Customer.png]]
![[PUT Customer 2.png]]
- DELETE Customer (api/delete/Id)
![[DELETE Customer.png]]

#### MoviesController
- GET Movies (api/movies)
![[GET Movies.png]]
- GET Movie (api/movies/Id)
![[GET Movie.png]]
- POST Movie (api/movies)
![[POST Movie.png]]
- PUT Movie (api/movies/Id)
![[PUT Movie.png]]
![[PUT Movie(2).png]]
- DELETE Movie (api/movies/Id)
![[DELETE Movie.png]]

## Pruebas con otros Frameworks

<hr>

<p class="justify">
 De igual manera, he decidido realizar un pequeño proyecto/aplicación en angular para manejar el apartado del cliente, y así, poder realizar las consultas y peticiones a la Web API.
</p>

<p class="justify">
 Adjunto una pequeña demostración en donde nuestra aplicación de angular hace un llamado a nuestra Web API mandando una solicitud GET al controlador CustomersController:
</p>

### Vista Customer en AngularJS
![[CustomerViewAngular.png]]

#### Componente Customer en AngularJS
![[CustomerAngular(2).png]]
![[CustomerAngular(1).png]]

### Parte técnica y declaración de la URL en Angular
<p class="justify">
 Creé un servicio el cual tiene declarada la URL de la API desarrollada en ASP.NET Core, de esta manera, solo es ir agregando los métodos que tenga el API para poder realizar las diferentes acciones:
</p>

#### SharedService AngularJS
![[SharedServiceAngular.png]]

# Notas Generales/Conclusiones

<hr>

<p class="justify">
 Aprovecho este espacio para poder comentar mis conclusiones y algunas notas extra.<br><br>
	
<strong>El objetivo de este proyecto/aplicación era demostrar las funciones básicas/principales de una aplicación RESTful, la cuál normalmente se implementa del lado del servidor y que está orientada a resolver peticiones por parte de los clientes manejando como parte base el protocolo HTTP y todas sus acciones/métodos.</strong>
</p>

<p class="justify">
 Debido a que era un proyecto de introducción, <strong>aun falta mayor funcionalidad respecto al curso</strong>.<br>
Algunos de esos conceptos faltantes era la implementación de autenticación de usuario, roles y otros aspectos utilizando Identity.
</p>

<p class="justify">
 Planeo aplicarlos en este proyecto debido a que.<strong> he escuchado y he visto distintas formas de validar las sesiones y la autenticación, tal como el caso de JWT (JsonWebToken) entre otros</strong>.
</p>

<p class="justify">
 Veo que el manejo de un ORM es de bastante ayuda debido a que, al refactorizar o realizar ajustes mayores dentro de una WebAPI, expone menos a los clientes que la consumen, ya que, si son ajustes no controlados, impactaría a todos los clientes enlazados a la misma.
</p>

<p class="justify">
 Realmente espero que este trabajo haya sido de su agrado y haya demostrado conceptos que he aprendido tanto de forma autodidácta, y con la ayuda del curso que me compartieron.<br>
<strong>Pienso que, uno de los obstáculos de este análisis, estudio e incluso implementación, fue el traspasar ciertos conocimientos en una arquitectura .NET Framework a .NET Core</strong>.
</p>