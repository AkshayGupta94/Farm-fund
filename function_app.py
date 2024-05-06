import azure.functions as func
import logging
import os
import base64
import requests
import json
from openai import AzureOpenAI

app = func.FunctionApp(http_auth_level=func.AuthLevel.ANONYMOUS)

@app.route(route="farmChat1")
def farmChat1(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    name = req.params.get('prompt')
    if not name:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            name = req_body.get('name')
    GPT4V_KEY = ""
    IMAGE_PATH_1 = "https://farmfundblob1.blob.core.windows.net/fileupload-crops-v/pest.jpg"
    IMAGE_PATH_2 = "https://farmfundblob1.blob.core.windows.net/fileupload-crops-v/healthy_crop.jpg"
    decoded_images=[]
    for image in [IMAGE_PATH_1, IMAGE_PATH_2]:
        response_image = requests.get(image)
        encoded_image = base64.b64encode(response_image.content)
        decoded_images.append(encoded_image.decode('ascii'))
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "Consider the first image as a image of the farm taken from a drone, what will you about the farm?"
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[0]}"
                            }
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
    jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')
    print(jsonResponse)
    data = {
        "message": jsonResponse,
        "images": ["https://farmfundblob1.blob.core.windows.net/fileupload-crops-v/pest.jpg"]  
    }

    # Convert the dictionary to a JSON string
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             jsonResponse,
             status_code=200
        )
    

@app.route(route="farmChat2")
def farmChat2(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    name = req.params.get('prompt')
    if not name:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            name = req_body.get('name')
    GPT4V_KEY = ""
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "Given the farmer has 100 acres of land and prices of wheat are 10 usd a kg and beans is 15 usd a kg and the farm is located in IOWA. Should farmer use multicropping? And which crops in which proportion should it grow?"
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
    jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')

    client = AzureOpenAI(
    api_version="2024-02-01",
    azure_endpoint="https://farmfund.openai.azure.com/",
    api_key=""
)

    result = client.images.generate(
    model="Dalle3", # the name of your DALL-E 3 deployment
    prompt="show an image of farm in iowa which has multicrop of wheat corn and beans at 30% 40% and 30%. Make it as realistic as possible. Make it detailed and show zoom of field. we only want to see the field and nothing else. It should illustrate and highlight multcropping",
    n=1
)

    image_url = json.loads(result.model_dump_json())['data'][0]['url']



    print(jsonResponse)
    data = {
        "message": jsonResponse,
        "images": [image_url]  
    }

    # Convert the dictionary to a JSON string
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             json_response,
             status_code=200
        )


@app.route(route="farmChat3")
def farmChat3(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')
    IMAGE_PATH_1 = "https://farmfundblob1.blob.core.windows.net/farm-images/1000_F_281816151_JkHQ5by3UiFm8WUS0DCUqqPxUmVFZ7Wi.jpg"
    IMAGE_PATH_2 = "https://farmfundblob1.blob.core.windows.net/farm-images/winter-wheat-spring-1-1024x683.jpg"
    decoded_images=[]
    for image in [IMAGE_PATH_1, IMAGE_PATH_2]:
        response_image = requests.get(image)
        encoded_image = base64.b64encode(response_image.content)
        decoded_images.append(encoded_image.decode('ascii'))
   
    GPT4V_KEY = ""
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "Given the farmer has 100 acres of land is growing crops. The pictures attached show current condition of the farm. idnetify crops growing in it. Does my current field give me best green credits possible? How can I make it more envirnoment friendly? The farm is located in IOWA USA. Make the answer in 250 words"
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[0]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[1]}"
                            }
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
    jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')

    

    print(jsonResponse)
    data = {
        "message": jsonResponse,
        "images": ["https://farmfundblob1.blob.core.windows.net/farm-images/1000_F_281816151_JkHQ5by3UiFm8WUS0DCUqqPxUmVFZ7Wi.jpg","https://farmfundblob1.blob.core.windows.net/farm-images/winter-wheat-spring-1-1024x683.jpg"]  
    }
    
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             json_response,
             status_code=200
        )


@app.route(route="investorChat1")
def investorChat1(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')
    IMAGE_PATH_1 = "https://farmfundblob1.blob.core.windows.net/farm-images/dry-corn-field-4-lanjee-chee.jpg"
    IMAGE_PATH_2 = "https://farmfundblob1.blob.core.windows.net/farm-images/f-chinaworms-a-20190814.jpg"
    IMAGE_PATH_3 = "https://farmfundblob1.blob.core.windows.net/farm-images/1000_F_281816151_JkHQ5by3UiFm8WUS0DCUqqPxUmVFZ7Wi.jpg"
    IMAGE_PATH_4 = "https://farmfundblob1.blob.core.windows.net/farm-images/58108_original.jpg"

    decoded_images=[]
    for image in [IMAGE_PATH_1, IMAGE_PATH_2,IMAGE_PATH_3,IMAGE_PATH_4]:
        response_image = requests.get(image)
        encoded_image = base64.b64encode(response_image.content)
        decoded_images.append(encoded_image.decode('ascii'))
   
    GPT4V_KEY = ""
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on investment, farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "The first two images are of happy farm and the next two images are of Will wheat farms . what do you think of these images? reply per farm as per the given images"
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[0]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[1]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[2]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[3]}"
                            }
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    jsonResponse = ""

# Loop until the length of jsonResponse is at least 100 characters
    while len(jsonResponse) < 350:  
        response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
        jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')
    

    

    print(jsonResponse)
    data = {
        "message": jsonResponse,
        "images": ["https://farmfundblob1.blob.core.windows.net/farm-images/1000_F_281816151_JkHQ5by3UiFm8WUS0DCUqqPxUmVFZ7Wi.jpg","https://farmfundblob1.blob.core.windows.net/farm-images/winter-wheat-spring-1-1024x683.jpg"]  
    }
    
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             json_response,
             status_code=200
        )


@app.route(route="investorChat2")
def investorChat2(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')
    IMAGE_PATH_1 = "https://farmfundblob1.blob.core.windows.net/farm-images/dry-corn-field-4-lanjee-chee.jpg"
    IMAGE_PATH_2 = "https://farmfundblob1.blob.core.windows.net/farm-images/cornpest_2_0.jpg"
    IMAGE_PATH_3 = "https://farmfundblob1.blob.core.windows.net/farm-images/1000_F_281816151_JkHQ5by3UiFm8WUS0DCUqqPxUmVFZ7Wi.jpg"
    IMAGE_PATH_4 = "https://farmfundblob1.blob.core.windows.net/farm-images/58108_original.jpg"

    decoded_images=[]
    for image in [IMAGE_PATH_1, IMAGE_PATH_2,IMAGE_PATH_3,IMAGE_PATH_4]:
        response_image = requests.get(image)
        encoded_image = base64.b64encode(response_image.content)
        decoded_images.append(encoded_image.decode('ascii'))
   
    GPT4V_KEY = ""
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on investment, farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "The first two images are of happy farm and the next two images are of Will wheat farms . Given its month of may now, what do you think of these images? reply per farm as per the given images and how rain in august affect them. Focus your answer more on rain aspect in 200 words."
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[0]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[1]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[2]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[3]}"
                            }
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    jsonResponse = ""

# Loop until the length of jsonResponse is at least 100 characters
    while len(jsonResponse) < 350:  
        response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
        jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')
    

    

    print(jsonResponse)
    data = {
        "message": jsonResponse,
        "images": [IMAGE_PATH_1,IMAGE_PATH_2,IMAGE_PATH_3,IMAGE_PATH_4]  
    }
    
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             json_response,
             status_code=200
        )




@app.route(route="marketChat1")
def marketChat1(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')
    IMAGE_PATH_1 = "https://farmfundblob1.blob.core.windows.net/farm-images/25583__11841.jpg"
    IMAGE_PATH_2 = "https://farmfundblob1.blob.core.windows.net/farm-images/ae-cornpatch.jpg"
    IMAGE_PATH_3 = "https://farmfundblob1.blob.core.windows.net/farm-images/winter-wheat-spring-1-1024x683.jpg"
  

    decoded_images=[]
    for image in [IMAGE_PATH_1, IMAGE_PATH_2,IMAGE_PATH_3]:
        response_image = requests.get(image)
        encoded_image = base64.b64encode(response_image.content)
        decoded_images.append(encoded_image.decode('ascii'))
   
    GPT4V_KEY = ""
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on investment, farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "assume these 3 pictures are of the same farm called Smith Family Farm. The first image is of 2020 , the second is of 2021 and third is of 2022. what can you tell? in you answer limit yourself to less than 300 words and mention farm name."
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[0]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[1]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[2]}"
                            }
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    jsonResponse = ""

# Loop until the length of jsonResponse is at least 100 characters
    while len(jsonResponse) < 350:  
        response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
        jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')
    

    

    print(jsonResponse)
    data = {
        "message": jsonResponse,
       "images": [IMAGE_PATH_1,IMAGE_PATH_2,IMAGE_PATH_3]  
    }
    
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             json_response,
             status_code=200
        )


@app.route(route="marketChat2")
def marketChat2(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')
    IMAGE_PATH_1 = "https://farmfundblob1.blob.core.windows.net/farm-images/25583__11841.jpg"
    IMAGE_PATH_2 = "https://farmfundblob1.blob.core.windows.net/farm-images/ae-cornpatch.jpg"
    IMAGE_PATH_3 = "https://farmfundblob1.blob.core.windows.net/farm-images/winter-wheat-spring-1-1024x683.jpg"
  

    decoded_images=[]
    for image in [IMAGE_PATH_1, IMAGE_PATH_2,IMAGE_PATH_3]:
        response_image = requests.get(image)
        encoded_image = base64.b64encode(response_image.content)
        decoded_images.append(encoded_image.decode('ascii'))
   
    GPT4V_KEY = ""
    headers = {
            "Content-Type": "application/json",
            "api-key": GPT4V_KEY,
        }
        
    GPT4V_ENDPOINT = 'https://farmfund1.openai.azure.com/openai/deployments/Farm-bot/extensions/chat/completions?api-version=2023-07-01-preview'

    payload = {
"enhancements": {
        "ocr":{
            "enabled":True
        },
        "grounding": {
            "enabled":False
        }
    },
        "messages": [
                {
                    "role": "system",
                    "content": [
                        {
                            "type": "text",
                            "text": "answer questions based on investment, farming, crops, agricultural , pest infestation based on images and assume you are an expert in this."
                        }
                        ]
                },
                {
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "assume these 3 pictures are of the same farm called Smith Family Farm. The first image is of 2020 , the second is of 2021 and third is of 2022. what can you tell?Can you say if these farm is sustainable? in you answer limit yourself to less than 300 words and mention farm name and focus on sustainability.Do not tell what information is missing or how assessment could have been made better"
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[0]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[1]}"
                            }
                        },
                        {
                            "type":"image_url",
                            "image_url": {
                                "url":f"data:image/jpeg;base64,{decoded_images[2]}"
                            }
                        }
                
            ]}],
                    "temperature": 0.7,
                    "top_p": 0.95,
                    "max_tokens": 800
            }
    jsonResponse = ""

# Loop until the length of jsonResponse is at least 100 characters
    while len(jsonResponse) < 350:  
        response = requests.post(GPT4V_ENDPOINT, headers=headers, json=payload)
        jsonResponse = response.json()['choices'][0]['message']['content'].strip().replace('\n', '')
    

    

    print(jsonResponse)
    data = {
        "message": jsonResponse,
       "images": [IMAGE_PATH_1,IMAGE_PATH_2,IMAGE_PATH_3]  
    }
    
    json_response = json.dumps(data)

   
    return func.HttpResponse(
             json_response,
             status_code=200
        )
