# Development Challenge - Refactorización 🚀

## 📌 Descripción del Proyecto
Este proyecto es una refactorización de un sistema que genera reportes de formas geométricas, mejorando su performance, escalabilidad, así como también la facilidad de manteniemiento.

Consigna original planteada : 

/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

Se aplicaron principios SOLID para mejorar la estructura de la aplicación y facilitar la extensión del código, a fines de que sea mucho más escalable y fácil de utilzar para nuevos desarrolladores.

---

## 🔍 **Principales Mejoras Realizadas**
✅ **Refactorización del código aplicando buenas practicas (principios SOLID, principalmente nos basamos en responsabilidad unida)**  
✅ **Se reemplazó el uso de constantes con una interfaz 'IFormaGeometrica' para mayor extensibilidad, generando así un contrato por cada tipo de objeto que se genere como formaGeometrica**  
✅ **Se separaron las clases de formas geométricas ('Cuadrado', 'Círculo', 'TriánguloEquilátero', 'Trapecio', 'Rectángulo')**  
✅ **Se implementó la clase 'Idioma' para soportar múltiples idiomas de manera escalable**  
✅ **Se creó 'Validador' para centralizar las validaciones y mejorar la reutilización del código**  
✅ **Se refactorizó 'GeneradorReporte' para eliminar dependencias innecesarias y hacerlo extensible**  
✅ **Se generó en Utils la clase ConstantesAplicacion para eliminar strings sueltos innecesarios en el código**  

---
## 📂 Estructura del Proyecto

DevelopmentChallenge 
    
    │── Interfaces │ 
            ├── IFormaGeometrica.cs │
    
    │── Classes │
             ├── Cuadrado.cs │
             ├── Circulo.cs │ 
             ├── TrianguloEquilatero.cs │ 
             ├── Trapecio.cs │ 
             ├── Rectangulo.cs │ 
             ├── GeneradorReporte.cs │ 
             ├── Validador.cs │ 
    
    │── Utils │ 
        ├── Constantes.cs │ 
    
    │── Tests │ 
        ├── DataTests.cs │ 
    
    │── README.md
---

## 📌 **Cómo Usar el Proyecto**
1️⃣ **Clonar el repositorio**  
'''cmd/sh
git clone https://github.com/tu-usuario/DevelopmentChallenge.git
cd DevelopmentChallenge
