# Desafio RedeHost

API foi idealizada utilizando  C# e o frameower ASP .NET CORE 2

## Instruções 
Os valores de estiverem entre `<>` devem ser alterados para os valores de sua preferência  
## GET

Link para realizar um get na API da biblioteca é http://`< hostname >`/api/date


## PUT 
Link para realizar um PUT na API da biblioteca é http://`< hostname >`/api/date/
Deve ser passado na URL os valores para a Alteração ficando 
 http://`< hostname >`/api/date/?date=`< Data(dd/mm/aaaa hh:mm) > ` &op= `< - ou + (+ = %2B)>` &value=`< numero Ex: 4000>`
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
