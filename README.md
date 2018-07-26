# Pronto Ambulancia

## Entorno de desarrollo
Pasos para seguir después de clonar el repositorio

1. Crear entorno virtual

	    virtualenv venv

2. Instalar dependencias o requerimientos

        pip install -r requirements.txt

4. Guardar nuevas dependencias (En caso de instalar nuevas dependencias)

        pip freeze > requirements.txt 

## Comandos a ejecutar (manage.py)

- Crear archivo migración
	
	    python manage.py makemigrations

- Migrar a la base de datos
	
	    python manage.py migrate

- Ejecutar localmente  (localhost:8000)
	
	    python manage.py runserver

- Crear super usuario (Recomendado únicamente si no se ha realizado)
	
	    python manage.py createsuperuser

## Crear apps

python manage.py startapp [NOMBRE APP]