# Pasos de instalación del framework y herramientas adicionales

## XUnit.net

XUnit.net es un proyecto de UnitTesting que viene por defecto en Visual Studio 2019 no se necesita instalar un complemento más aparte ya que el proyecto contiene el unit test.
Sin embargo los pasos para instalar un nuevo proyecto XUnit.net son los siguientes.

para su aplicación a un proyecto se debe añadir un nuevo proyecto en la pestaña Solution Explorer 

- Abrir el panel de solution ‘Simpson App’.
- Abir el panel ‘Add’
- Pulsar en New Proyect.

Al abrirse la ventana de Add a new proyect buscamos el proyecto xunit y seleccionamos la xUnit Test Proyect que tiene un logo de una consola, un probeta y el nombre del lenguaje C# luego se realizan los siguientes pasos.

- Seleccionamos el botón next en la esquina inferior izquierda.
- Colocamos un nombre en la parte de Proyect name de la siguiente forma: SimpsonApp.[nombre_del_proyecto]
- Pulsamos next nuevamente en la esquina inferior izquierda.
- Seleccionamos en el Target Framework la opción “.Net Core 3.1 (Long-term support)”.
- Seleccionamos el botón create en la esquina inferior izquierda.

Una vez seguidos los pasos se crea un nuevo proyecto de Unittest en el cual se pueden añadir nuevas clases de UnitTest para diferentes capas del proyecto, adicionalmente se tiene que hacer una referencia al proyecto que queremos verificar.

- Abrimos la pestaña que se acaba de crear pulsamos el botón derecho y seleccionamos Add Project Reference.

- Marcamos los proyectos que queremos realizar tests y presionamos el botón Ok.

Una vez añadida la referencia podemos abrir las subcarpetas del proyecto SimpsonApp y de esa forma obtener las clases que se desea verificar.

## Fine Code Coverage
Ya que la opción de visualizar gráficamente el code coverage de cada file de Visual Studio sólo está disponible para la versión: Visual Studio Enterprise se busca una alternativa gratis.

Fine Code Coverage ofrece visualizar fácilmente la cobertura del código de prueba de la unidad de forma gratuita en Visual Studio Community Edition (y otras ediciones también).

Los pasos de instalación de esta herramienta son:

- Ir al enlace: Fine Code Coverage - Visual Studio Marketplace.
- Dar click en el botón Download.
- Si el navegador lo requiere confirmar la descarga.
- Abrir el archivo .vsix descargado (Visual Studio debe estar cerrado).
- Continuar con las opciones de instalación.
- Abrir Visual Studio
- Abrir la opción Ver de las opciones en la parte superior
- Click en Otras ventanas 
- Click en Fine Code Coverage

Para verificar su funcionamiento abrimos el proyecto de Unittest y corremos todas las pruebas en la parte inferior de la pantalla debería mostrarnos una sección llamada Fine Code Coverage con los porcentajes del código cubierto para cada clase.

## Moq
Moq es el marco de mocking más popular y amigable para .NET. Se utiliza en pruebas unitarias para aislar su clase bajo prueba de sus dependencias y asegurarse de que los métodos adecuados en los objetos dependientes se están llamando.

En este caso este paquete se usa para aislar los controladores e inyectar las dependencias manualmente. 

Para instalarlo seguimos los siguientes pasos:
- Dirigirse a la sección de Dependencias/paquetes: del proyecto en la ventana de Explorador de Soluciones de Visual Studio
- Click derecho y seleccionar Administrador Nugget
- Buscar el paquete: Moq
- Instalarlo

# Pasos para correr los casos de Prueba

Una vez abierta la solución del repositorio en Visual Studio

- Dar click en el proyecto UnitTesting de los dos que estan en el repositorio
- Dar click en la pestaña Prueba de la barra de herramientas de la parte superior.
- Dar click en Ejecutar todas las pruebas
- Se debería mostrar el Explorador de pruebas
- Para ver el Code Coverage dar click en Ver de la barra de herramientas de la parte superior
- Desplegar la lista de Otras ventanas
- Dar click en Fine Code Coverage