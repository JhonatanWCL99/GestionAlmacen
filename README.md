# API REST PARA LA GESTION DE ALMACEN

Implementacion de una REST API .NET Core que consta de los siguientes servicios:


## Gestion de Producto

#### Obtener todos los productos

```http
  GET /api/Productos
```



#### Obtener un producto

```http
  GET /api/Productos/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id del producto a obtener |

#### Registrar un producto

```http
  POST /api/Productos
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `nombre` | `string` | **Required**. |
| `costo` | `float` | **Required**. |

#### Actualizar un producto
```http
  PUT /api/Productos/${id}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id`      | `int` | **Required**. Id del producto a editar |
| `nombre` | `string` | **Opcional**. |
| `costo` | `float` | **Opcional**. |

#### Eliminar un producto

```http
  DELETE /api/Productos/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id del producto a eliminar |

## Gestion de Inventario

#### Obtener todos los inventarios

```http
  GET /api/Inventarios
```

#### Obtener un inventario

```http
  GET /api/Inventarios/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id del inventario a obtener |

#### Registrar un inventario

```http
  POST /api/Inventarios
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `fecha` | `date` | **Required**. |
| `detallesInventario:` | `Json` | **Required**..  |


##### Ejemplo

```json
{
  "fecha": "2023-02-19T21:03:59.255Z",
  "detallesInventario": [
    {
      "cantidad": 2,
      "ProductoId": 1 // Id del Producto
    },
    {
      "cantidad": 5,
      "ProductoId": 2 // Id del Producto
    }
  ]
}
```

#### Eliminar un inventario

```http
  DELETE /api/Inventarios/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id del inventario a eliminar |

## Gestion de Venta

#### Obtener todos las ventas

```http
  GET /api/Ventas
```

#### Obtener una venta

```http
  GET /api/Ventas/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id de la venta a obtener |

#### Registrar una venta

```http
  POST /api/Ventas
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `fecha` | `date` | **Required**. |
| `detallesVenta:` | `Json` | **Required**..  |


##### Ejemplo

```json
{
  "fecha": "2023-02-19T21:03:59.255Z",
  "detallesVenta": [
    {
      "cantidad": 2,
      "precio": 15,
      "ProductoId": 1 // Id del Producto
    },
    {
      "cantidad": 3,
      "precio": 20,
      "ProductoId": 2 // Id del Producto
    }
  ]
}
```
