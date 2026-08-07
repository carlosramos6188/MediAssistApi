# MediAssist API

<div align="center">

# Sistema de Gestión Médica con Inteligencia Artificial

API REST desarrollada con **ASP.NET Core 8**, **Entity Framework Core**, **SQLite** e **Inteligencia Artificial (Groq)**.

Analiza síntomas escritos en lenguaje natural y recomienda una especialidad médica, nivel de prioridad y recomendaciones generales.

---

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge)
![C#](https://img.shields.io/badge/C%23-12-blue?style=for-the-badge)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-Core-green?style=for-the-badge)
![SQLite](https://img.shields.io/badge/SQLite-Database-blue?style=for-the-badge)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-success?style=for-the-badge)
![Groq AI](https://img.shields.io/badge/Groq-AI-orange?style=for-the-badge)

</div>

---

# Tabla de Contenido

- Descripción
- Objetivos
- Tecnologías
- Arquitectura
- Funcionalidades
- Base de Datos
- Endpoints
- Integración con IA
- Instalación
- Evidencias
- Autor

---

# Descripción

**MediAssist API** es una API REST desarrollada en ASP.NET Core 8 que permite administrar información de pacientes, médicos y especialidades médicas.

Además incorpora Inteligencia Artificial mediante **Groq**, capaz de analizar síntomas escritos en lenguaje natural y generar:

- Especialidad médica sugerida
- Nivel de prioridad
- Análisis preliminar
- Recomendaciones generales

Toda la información generada por la IA queda almacenada en la base de datos para futuras consultas.

> **Importante:** Los resultados generados por la IA son únicamente una ayuda informativa y **no reemplazan el diagnóstico de un profesional de la salud**.

---

# Objetivos

- Implementar una API REST moderna.
- Aplicar Entity Framework Core.
- Utilizar SQLite como base de datos.
- Integrar Inteligencia Artificial mediante Groq.
- Documentar la API con Swagger.
- Aplicar buenas prácticas utilizando DTOs y arquitectura por capas.

---

# Tecnologías Utilizadas

| Tecnología | Uso |
|------------|-----|
| ASP.NET Core 8 | Framework principal |
| C# | Lenguaje |
| Entity Framework Core | ORM |
| SQLite | Base de datos |
| Swagger/OpenAPI | Documentación |
| Groq API | Inteligencia Artificial |
| Git | Control de versiones |
| GitHub | Repositorio |

---

# Arquitectura

```text
                Cliente

                   │

                   ▼

          Controllers (API)

                   │

                   ▼

             Services

                   │

        ┌──────────┴──────────┐
        ▼                     ▼

 Entity Framework         Groq API

        │
        ▼

     SQLite
```

---

# Funcionalidades

## Pacientes

- Crear paciente
- Consultar pacientes
- Consultar por ID
- Actualizar paciente
- Eliminar paciente

---

## Médicos

- Crear médico
- Consultar médicos
- Actualizar médico
- Eliminar médico

Incluye validación para verificar que la especialidad exista.

---

## Especialidades

- CRUD completo

---

## Inteligencia Artificial

La IA permite:

- Analizar síntomas.
- Recomendar una especialidad.
- Asignar prioridad.
- Generar recomendaciones.
- Guardar el historial del análisis.

---

# Base de Datos

La aplicación utiliza SQLite.

### Tablas

- Pacientes
- Médicos
- Especialidades
- AnalisisIA

Las migraciones son administradas mediante Entity Framework Core.

---

# Endpoints

## Pacientes

| Método | Endpoint |
|---------|----------|
| GET | /api/Pacientes |
| GET | /api/Pacientes/{id} |
| POST | /api/Pacientes |
| PUT | /api/Pacientes/{id} |
| DELETE | /api/Pacientes/{id} |

---

## Especialidades

| Método | Endpoint |
|---------|----------|
| GET | /api/Especialidades |
| GET | /api/Especialidades/{id} |
| POST | /api/Especialidades |
| PUT | /api/Especialidades/{id} |
| DELETE | /api/Especialidades/{id} |

---

## Médicos

| Método | Endpoint |
|---------|----------|
| GET | /api/Medicos |
| GET | /api/Medicos/{id} |
| POST | /api/Medicos |
| PUT | /api/Medicos/{id} |
| DELETE | /api/Medicos/{id} |

---

## Inteligencia Artificial

| Método | Endpoint |
|---------|----------|
| POST | /api/IA/analizar |
| GET | /api/IA/historial |

---

# Integración con IA

El servicio utiliza la API de **Groq** para analizar síntomas escritos por el usuario.

### Ejemplo

Entrada:

```
Tengo fiebre, dolor de garganta y mucha tos.
```

Salida:

```json
{
  "especialidad": "Infecciosas",
  "prioridad": "Alta",
  "analisis": "...",
  "recomendaciones": "..."
}
```

Cada análisis queda registrado automáticamente en la tabla **AnalisisIA**.

---

# Instalación

## Clonar el repositorio

```bash
git clone https://github.com/carlosramos6188/MediAssistApi.git
```

## Restaurar paquetes

```bash
dotnet restore
```

## Ejecutar migraciones

```bash
dotnet ef database update
```

## Ejecutar el proyecto

```bash
dotnet run
```

---

# Documentación

Una vez iniciada la aplicación:

```
https://localhost:XXXX/swagger
```

Swagger permite probar todos los endpoints desde el navegador.

---

# Evidencias de funcionamiento

## Pacientes

### Crear paciente

![Crear Paciente](Documentacion/Pacientes/01_POST_Paciente_Valido.png)


## Médicos

### Crear médico

![Crear Médico](Documentacion/Medicos/01_POST_Medico_Valido.png)

---

## Especialidades

### Crear especialidad

![Crear Especialidad](Documentacion/Especialidades/01_POST_Especialidad_Valido.png)

---

## Inteligencia Artificial

### Análisis de síntomas

![Analizar Síntomas](Documentacion/IA/01_IA_Analizar_Valido.png)

---

### Historial de análisis

![Historial IA](Documentacion/IA/03_IA_Historial.png)

---

# Autor

**Carlos Andrés Ramos Peña**

**Luis Felipe Silvera Valega**

**Ingeniería de Sistemas**

Proyecto desarrollado como evidencia académica para el **Diplomado en Programación con .NET**.

GitHub:

https://github.com/carlosramos6188/MediAssistApi

---

# Gracias por visitar este proyecto.

Si este proyecto te resulta útil, puedes dejar una ⭐ en el repositorio.
