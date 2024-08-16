
README

1. Open project on visual studio 2022
2. Start project
3. Get localhost url 
4. Return response
5. Have unit test project

Example:
https://localhost:7205/api/Jug

request:
{
  "x_capacity": 2,
  "y_capacity": 10,
  "z_capacity": 4
}

response:
[
    {
        "step": 1,
        "bucketX": 2,
        "bucketY": 0,
        "action": "Fill bucket y"
    },
    {
        "step": 2,
        "bucketX": 0,
        "bucketY": 2,
        "action": "Transfer from bucket x to bucket y"
    },
    {
        "step": 3,
        "bucketX": 2,
        "bucketY": 2,
        "action": "Fill bucket y"
    },
    {
        "step": 4,
        "bucketX": 0,
        "bucketY": 4,
        "action": "Transfer from bucket x to bucket y"
    }
]