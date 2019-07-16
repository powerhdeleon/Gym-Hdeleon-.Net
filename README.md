# Gym-Hdeleon-.Net
Código fuente de para software de gimnasios.

Licencia Apache 2.0, leer el archivo License.txt anexo al repositorio.

Para ver su funcionalidad clic en el enlace: https://www.youtube.com/watch?v=6BKx5J3zRCQ

El código fuente esta hecho para correr con 4.0 framework de .Net y la base de datos es mysql. 

La base de datos esta en la carpeta BD. Algo muy importante es que se inserta un registro en la tabla socios, el registro corresponde a el socio visita el cual tiene el id=1000. Deben poner la tabla de socio que el autoincrement continue en el 1000 osea que el siguiente sea el 1001 ejecutando el siguiente query:

ALTER TABLE socio AUTO_INCREMENT=1000;
