# Starbucks API
This project was generated with Net Core 6 And EF InMemoryDatabase.

# Usuarios de Prueba
- La contraseña para todos los usuarios es: 123

user1@gmail.com, user2@gmail.com
- Puede acceder a crear, ver y eliminar sus ordenes.

employee1@gmail.com
- Puede ver las ordenes creadas y ejecutarlas.

supervisor1@gmail.com
- Puede facturar las ordenes ejecutadas y ajustar el stock.

admin1@gmail.com
- Puede gestionar usuarios y ver todas las ordenes.



# Starbucks.Ecommerce.Services.Api
## Version: 1.0

### /api/Auth

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ingredients

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ingredients/{id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Orders/{id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Orders

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Orders/{id}/execute

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Orders/{id}/invoice

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Products

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Products/{productId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| productId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Provinces

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Roles

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Users/{userId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| userId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Users

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Users/{id}

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
