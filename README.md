# Bootcamp Microsoft DIO - Inteligência Artificial

## 🚀 Objetivo
Este projeto tem como objetivo empregar técnicas avançadas de Machine Learning para prever as vendas de sorvetes em uma sorveteria, contribuindo para uma gestão de estoque mais eficiente e melhorando a capacidade de antecipar a demanda futura com base nos dados históricos.

### Dados de Análise:
Os dados estão disponíveis no arquivo sorvetes_ia.csv, com as seguintes colunas:

* Data: Data da venda.
* Vendas_Dia: Quantidade de sorvetes vendidos no dia.
* Condicoes_Climaticas: Indicador das condições climáticas no dia da venda.

## 🛠️ Construído com

* Visual Studio 2022
* C# .NET
* Microsoft Azure

## Projeto C# .NET

O arquivo [LabDioAI01/SalesForecastService.cs](LabDioAI01/SalesForecastService.cs) tem as chamadas para os pontos de extremidades criados no Azure

client.BaseAddress = new Uri("https://icecreamsalesiamodel.centralus.inference.ml.azure.com/score");

## Etapas do Projeto:

### Análise Exploratória de Dados (EDA):
Explorar o conjunto de dados para entender a distribuição, tendências e padrões.

### Treinamento do Modelo:
Utilizar técnicas de regressão, especificamente os algoritmos RandomForest e LightGBM, para treinar um modelo com base nas vendas históricas.
Dividir os dados em conjuntos de treinamento e teste para avaliação de desempenho.

### Avaliação do Modelo:
Avaliar a precisão do modelo usando métricas como RMSE (Root Mean Square Error).

### Configuração no Azure:
Configurar um ambiente no Azure Machine Learning para treinamento e implantação do modelo.
Utilizar recursos do Azure para armazenar dados e resultados.

### Implantação e Ponto de Extremidade:
Implantar o modelo treinado como um serviço no Azure, disponibilizando um ponto de extremidade para realizar previsões em tempo real.
Criar uma integração em C#.NET para acessar o ponto de extremidade, permitindo o consumo fácil do serviço.

### Previsão Futura:
Utilizar o modelo para prever as vendas de sorvetes nos próximos meses, contribuindo para o planejamento adequado do estoque.

## Etapas de criação do modelo no Azure

### Resumo

* Crie uma conta no portal do Azure em https://portal.azure.com
* Busque por Machine Learning, e crie uma novo recurso de Azure Machine Learning 
* Abra o site de Machine Learning da Microsoft em https://ml.azure.com
* Crie um novo job automático de machine learning
* Selecione o tipo de tarefa como: Regression
* Em Data Source selecione "From web files" e digite a url do arquivo sorvetes_is.csv disponibilizado pelo GIT (raiz do projeto)
* Configure os dados do arquivo csv no Azure
* Configure algumas informações sobre a tarefa que será executada no Azure ML como tempo da tarefa, servidores, etc.
* Inicie a execução da tarefa
* Faça o deploy da tarefa executada em um modelo e execute os testes no json criado no Azure
* Crie os pontos de extremidades e acesse como um serviço Restful
* No código C# .NET deste projeto, altere a chave de autenticação do Azure e os pontos de extremidades para chamar o serviço criado.

### Passo a passo detalhado
https://microsoftlearning.github.io/mslearn-ai-fundamentals/Instructions/Labs/01-machine-learning.html




