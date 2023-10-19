# VeterinariaCampus 🐶🐱⚕️
## Introduccion
La VeterinariaCampus es un proyecto desarrollado en NetCore con el proposito de elaborar una api funcional que permita gestionar una veterinaria, implementando funcionalidades con las cuales se pueda manipular informacion relacionada con el agendamiento de citas, medicamentos, proveedores, compras, etc.
## Caracteristicas
- Gestion de Veterinarios
- Gestion de Mascotas
- Movimiento de Medicamentos
- Registro de Usuario
- Asignacion de Roles
- Inicio de Sesion
## Consultas
### Basicas
- Crear
```
[POST]localhost:5022/api/[Nombre de la entidad]/Create
```
- Editar
```
[PUT]localhost:5022/api/[Nombre de la entidad]/Update
```
- Eliminar
```
[DELETE]localhost:5022/api/[Nombre de la entidad]/Delete/[id]
```
- Conseguir Por Id
```
[GET]localhost:5022/api/[Nombre de la entidad]/Obtener/[id]
```
- Listar v1.0
```
[GET]localhost:5022/api/[Nombre de la entidad]/
```
- Listar v1.1
```
[GET]localhost:5022/api/[Nombre de la entidad]/
```
```
X-Version : 1.1
```
### JWT
#### Registrar
- Endpoint
```
http://localhost:5022/api/User/Register/
```
#### Token
- Endpoint
```
http://localhost:5022/api/User/Token/
```
#### Añadri rol
- Endpoint
```
http://localhost:5022/api/User/addrole/
```
####  Refresh Token
```
http://localhost:5022/api/User/refresh-token/
```
### Visualizar los Veterinarios Cuya Especialidad Sea Cirujano Vascular
#### Endpoint
```
localhost:5022/api/Veterinario/GetCirujanos
```
#### Respuesta
```
[
  {
    "id": 1,
    "nombre": "anderson",
    "correo": "anderson@gmail.com",
    "telefono": 64829173,
    "especialidad": "Cirujano Vascular"
  }
]
```
### Listar los Medicamentos Que Pertenezcan a el Laboratorio Genfar
#### Endpoint
```
localhost:5022/api/Medicamento/genfar
```
#### Respuesta
```
[
  {
    "id": 1,
    "nombre": " Paracetamol",
    "cantidadDisponible": 40,
    "precio": 90.0,
    "idLaboratorioFk": 1
  },
  {
    "id": 2,
    "nombre": " Pazatar",
    "cantidadDisponible": 60,
    "precio": 120.0,
    "idLaboratorioFk": 1
  }
]
```
### Mostrar las mascotas que se encuentren registradas cuya especie sea felina
#### Endpoint
```
localhost:5022/api/Mascota/felino
```
#### Respuesta
```
[
  {
    "id": 2,
    "nombre": "Juan",
    "fechaNacimiento": "2023-12-12",
    "raza": "Naranja",
    "especie": "Felino",
    "idPropietarioFk": 1
  }
]
```
### Listar las Mascotas y sus Propietarios Cuya Raza sea Golden Retriver
#### Endpoint
```
localhost:5022/api/Mascota/GoldenR
```
#### Respuesta
```
[
  {
    "id": 3,
    "nombre": "firulais",
    "fechaNacimiento": "2023-01-01",
    "raza": "golden retriever",
    "propietario": {
      "id": 2,
      "nombre": "Jhoan",
      "correo": " jhoan@gmail.com",
      "telefono": 293934
    }
  }
]
```
### Listar los Propietarios y sus Mascotas
#### Endpoint
```
localhost:5022/api/Propietario/GetWithPets
```
#### Respuesta
```
[
  {
    "id": 1,
    "nombre": "Anderson",
    "correo": "Anderson@gmail.com",
    "telefono": 64829173,
    "mascotas": [
      {
        "id": 2,
        "nombre": "Juan",
        "fechaNacimiento": "2023-12-12",
        "raza": null,
        "especie": null,
        "idPropietarioFk": 1
      }
    ]
  },
  {
    "id": 2,
    "nombre": "Jhoan",
    "correo": " jhoan@gmail.com",
    "telefono": 293934,
    "mascotas": [
      {
        "id": 3,
        "nombre": "firulais",
        "fechaNacimiento": "2023-01-01",
        "raza": null,
        "especie": null,
        "idPropietarioFk": 2
      }
    ]
  },
  {
    "id": 3,
    "nombre": "Christian",
    "correo": " chrisitian@gmail.com",
    "telefono": 233242,
    "mascotas": []
  }
]
```
### Listar los Medicamentos Que Tenga un Precio de Venta Mayor a 50000
#### Endpoint
```
localhost:5022/api/Medicamento/morethan5000
```
#### Respuesta
```
[
  {
    "id": 2,
    "nombre": " Pazatar",
    "cantidadDisponible": 60,
    "precio": 5001.0,
    "idLaboratorioFk": 1
  }
]
```
### Listar las Mascotas Que Fueron Atendidas Por Motivo de Vacunacion en el Primer Trimestre del 2023
#### Endpoint
```
http://localhost:5022/api/Cita/CitaPrimerTrimestre2023
```
#### Respuesta
```
[
  {
    "id": 2,
    "nombre": "Juan",
    "fechaNacimiento": "2023-12-12",
    "raza": "Naranja",
    "especie": "Felino",
    "idPropietarioFk": 1
  }
]
```
### Listar Todas Las Mascotas Agrupadas Por Especie
#### Endpoint
```
localhost:5022/api/especie/WithPets
```
#### Respuesta
```
{
  "search": null,
  "pageIndex": 1,
  "pageSize": 10,
  "total": 3,
  "registers": [
    {
      "nombre": "Canina",
      "mascotas": [
        {
          "id": 3,
          "nombre": "firulais",
          "fechaNacimiento": "2023-01-01",
          "raza": null,
          "especie": "Canina",
          "idPropietarioFk": 2
        }
      ]
    },
    {
      "nombre": "Felino",
      "mascotas": [
        {
          "id": 2,
          "nombre": "Juan",
          "fechaNacimiento": "2023-12-12",
          "raza": null,
          "especie": "Felino",
          "idPropietarioFk": 1
        }
      ]
    },
    {
      "nombre": "Pez",
      "mascotas": []
    }
  ],
  "totalPages": 1,
  "hasPreviousPage": false,
  "hasNextPage": false
}
```
### Listar las mascotas que fueron atendidas por un determinado veterinario
#### Endpoint
```
localhost:5022/api/cita/GetPerVeterinario?nombre=[Nombre del veterinario]
```
#### Respuesta
```
[
  {
    "id": 2,
    "nombre": "Juan",
    "fechaNacimiento": "2023-12-12",
    "raza": "Naranja",
    "especie": "Felino",
    "idPropietarioFk": 1
  }
]
```
### Listar los proveedores que me venden un determinado medicamento
#### Endpoint
```
localhost:5022/api/proveedor/GetPerMed?nombre=[nombre del medicamento]
```
#### Respuesta
```
[
  {
    "id": 4,
    "nombre": "christian",
    "direccion": "tu casa",
    "telefono": 32324
  }
]
```
### Listar la Cantidad de Mascotas Que Pertenecen a Una Raza
#### Endpoint
```
localhost:5022/api/Raza/GetWithCount
```
#### Respuesta
```
{
  "search": null,
  "pageIndex": 1,
  "pageSize": 10,
  "total": 2,
  "registers": [
    {
      "nombre": "Naranja",
      "cantidadMascotas": 1
    },
    {
      "nombre": "golden retriever",
      "cantidadMascotas": 1
    }
  ],
  "totalPages": 1,
  "hasPreviousPage": false,
  "hasNextPage": false
}
```
### Listar Todos Los Movimientos de Medicamentos y El Valor Total De Cada Movimiento
#### Endpoint
```
localhost:5022/api/movimientomedicamento/GetWithPrice
```
#### Respuesta
```
{
  "search": null,
  "pageIndex": 1,
  "pageSize": 10,
  "total": 1,
  "registers": [
    {
      "id": 1,
      "fecha": "2012-12-12",
      "tipoMovimiento": "Vender",
      "total": 4880.0
    }
  ],
  "totalPages": 1,
  "hasPreviousPage": false,
  "hasNextPage": false
}
```
## Autor
- Anderson Cespedes
