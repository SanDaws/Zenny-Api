
# API Reference

## summary

- [Category](#Category)


## Category
#### Get all items

```http
  GET /api/Category
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Return all the categories  |

## Movement

#### Get all the movements with an specific user_id

```http
  GET /api/v1/movement/{id}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id`      | `int`    | **Required**. User_Id  |

#### Get all the incomes with an specific user_id

```http
  GET /api/v1/movement/getIncomes/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. User_Id             |

#### Get all the expenses with an specific user_id

```http
  GET /api/v1/movement/getExpenses/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. User_Id |

#### Get the total expenses of an specific user

```http
  GET /api/v1/movement/getTotalExpenses/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. user_id |

Returns the total expenses of an specific user for the current month

#### Get the total incomes of an specific user

```http
  GET /api/v1/movement/getTotalIncomes/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. user_id |

 Returns the total incomes of an specific user for the current month

#### Get all the expenses with an specific user_id and category_id

```http
  GET /api/v1/movement/expenses/{id}/{categoryId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `user_id`      | `int` | **Required**.    User_Id           |
| `category_id`  | `int` | **Required**.  category_id  |


#### Create a movement


```http
  POST /api/createMovement 
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `None`    | `JSON`   | N/A                               |


#### Delete a movement by its id
```http
  DELETE /api/delete/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. id                  |

#### Delete all movements from an user_id

```http
  DELETE /api/delete/deleteAllMovements/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. user_Id             |

#### Update a movement by the id movement

```http
  PUT /api/MovementUpdate/{id} 
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. id                  |


## SubscriptionType

#### Get all suscription types

```http
  GET /api/v1/SubscriptionType
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Return all the Subscription types  |

## Transanction Type

#### Get all Get all the transaction types

```http
  GET /api/v1/SubscriptionType
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns a all the transaction type objects |

## Users

#### Create an user

```http
  POST /api/v1/User/Register
```


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `None`    | `JSON`   | N/A                               |

#### Login an user

```http
  POST /api/v1/User/Login
```


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `None`    | `JSON`   | N/A                               |

#### Delete an user by id

```http
  DELETE /api/delete/deleteAllMovements/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. user_Id             |

#### Update user by id

```http
  PUT /api/v1/UserUpdate/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. the user id                  |




