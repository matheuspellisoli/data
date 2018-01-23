# Desafio RedeHost

API foi idealizada utilizando  C# e o frameower ASP .NET CORE 2

## Instruções 
Os valores de estiverem entre `<>` devem ser alterados para os valores de sua preferência  
## GET

Link para realizar um get na API da biblioteca é http://`desafio-redehost.herokuapp.com`/api/date


## PUT 
Link para realizar um PUT na API da biblioteca é http://`desafio-redehost.herokuapp.com`/api/date/
Deve ser passado na pelo formbody o Json

```javascript
{ 
  date: "1/1/1917 4:0",
  op: "-",
   value: "6" 
}
```

### Curl

curl -X PUT \http://`desafio-redehost.herokuapp.com`/api/date/ -s -w '%{http_code}\n' -d '{ date: "1/1/1917 4:0", op: "+", value: "7" }' -H "Content-Type: application/json" 

## Retorno da data 
Ele retorna um Json

```javascript
{
"day":1,
"month":1,
"year":1917,
"hour":4,
"minute":60,
"stringDate":"1/1/1917 4:60"
}

```

#### HTTP Status Code 500
  Quando retornar verifique se informou a data no formato coreto(dd/mm/aaaa hh:mm)

