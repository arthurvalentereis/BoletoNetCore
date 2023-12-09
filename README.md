[![Build status](https://ci.appveyor.com/api/projects/status/fv9cin5fmpaqri7o?svg=true)](https://ci.appveyor.com/project/carloscds/boletonetcore)
[![Nuget count](http://img.shields.io/nuget/v/BoletoNetCore.svg)](https://www.nuget.org/packages/BoletoNetCore/)
[![Nuget count](http://img.shields.io/nuget/v/BoletoNetCore.PDF.svg)](https://www.nuget.org/packages/BoletoNetCore.PDF/)
[![Issues open](https://img.shields.io/github/issues/BoletoNet/boletonetCore.svg)](https://huboard.com/BoletoNet/boletonetcore/)
[![Coverage Status](https://coveralls.io/repos/github/BoletoNet/boletonetcore/badge.svg?branch=master)](https://coveralls.io/github/BoletoNet/boletonetcore?branch=master)
[![MyGet Ultimo PR](https://img.shields.io/myget/boletonetcorebuild/v/boletonetcore.svg)](https://www.myget.org/gallery/boletonetcorebuild)

# Status
![Alt](https://repobeats.axiom.co/api/embed/624e926e9d7b272a2137660ee27c9575d5aec3ac.svg "Repobeats analytics image")

# BoletoNetCore
Esta é uma versão baseado no Boleto2Net, mas para funcionar com .NET Core

Foi criado um novo projeto para não quebrar a compatibilidade com aplicações que usam .NET inferior ao 4.6.1

## Documentos
### Banco do Brasil:
https://bb.com.br/docs/pub/emp/empl/dwn/000Completo.pdf  (CNAB e Segmentos)
https://www.bb.com.br/docs/pub/emp/empl/dwn/Doc3526SegtoE.pdf Conciliação bancária

### Banco do Bradesco
- [Todas documentações CNAB400/CNAB240/MT940](https://banco.bradesco/html/pessoajuridica/solucoes-integradas/outros/layout-de-arquivo.shtm)  
- [MT 940 lastest version](https://banco.bradesco/assets/pessoajuridica/pdf/solucoes-integradas/outros/layout-de-arquivo/conciliacao_bancaria_mt940.pdf)
- [CNAB240 Conciliação bancária](https://banco.bradesco/assets/pessoajuridica/pdf/solucoes-integradas/outros/layout-de-arquivo/conciliacao_bancaria_240_posicoes_v_5.pdf)

### Santander
- [Documentação Santander não possui conciliação](https://cms.santander.com.br/sites/WPS/documentos/arq-cobranca-portugues-jul22/22-07-14_131739_h7815-layout-cobranca-cnab-240-posicoes-padrao-santander-multibanco-julho-2022-v4.pdf)


## Exemplos e artigos de parser MT940
- [Artigo detalhado (inglês)](https://web.archive.org/web/20200618100100/https://deutschebank.nl/nl/docs/MT94042_EN.pdf)

- [construtor de cada código do MT940](https://github.com/ksdev-pl/mbank-mt940-parser/blob/master/src/Mt940Parser.php) 

-[possui exemplos do arquivo MT 940](https://github.com/mjebrahimi/SharpMt940Lib.Core/blob/master/Raptorious.SharpMt940Lib.Tests/Samples/abnamro.txt)

SAP MT940 Documentation 
https://blogs.sap.com/2020/06/29/steps-to-activate-electronic-bank-reconciliation-statement-mt940-format-part-i/ (Steps to Activate Electronic Bank Reconciliation Statement – MT940 Format – Part I)
https://blogs.sap.com/2020/08/05/search-string-in-electronic-bank-reconciliation-mt940-format-part-ii/ (Search String in Electronic Bank Reconciliation – MT940 Format – Part II)


Detalhamento dos Segmentos do modelo CNAB
https://ajuda.wk.com.br/622/fn/03.Cadastros/03.03.Leiautes/03.03.02.Gerador_de_Leiautes_de_Arquivos_de_Remessa/CNAB_240_-_Gerador_de_Leiautes_de_Arquivos_de_Remessa.htm

### Carteiras Homologadas
* Banrisul (041) - Carteira 1
* Bradesco (237) - Carteira 09
* Brasil (001) - Carteira 17 (Variações 019 027 035)
* Caixa Econômica Federal (104) - Carteira SIG14
* Cecred/Ailos (085) - Carteira 1
* Itau (341) - Carteira 109, 112
* Safra (422) - Carteira 1
* Santander (033) - Carteira 101
* Sicoob (756) - Carteira 1-01
* Sicredi (748) - Carteira 1-A

### Carteiras Implementadas (Não foi homologada. Falta teste unitário)
* Banco do Brasil (001) - Carteira 11 (Variação 019)
* Banco CrediSIS (097) - Carteira 18
> Atenção: Para manter a ordem do projeto, qualquer solicitação de Pull Request de um novo banco ou carteira implementada, deverá seguir o formato dos bancos/carteiras já implementados e vir acompanhado de teste unitário da geração do boleto (PDF), arquivo remessa e geração de 9 boletos, com dígitos da linha digitável variando de 1 a 9, checando além do próprio dígito verificador, o cálculo do nosso número, linha digitável e código de barras.

### Pre requisitos
* Visual Studio 2017 ou superior
* .NET Framework 4.6.1 ou superior

## Como Contribuir

[Leia o arquivo contributing.md](contributing.md)

Este projeto está dividido em 3 partes: 

### BoletoNetCore (Projeto Principal)
Responsável por guardar toda a lógica de leitura de remessa e retorno de arquivos e regras e impressão do boleto em hipertexto. Por ser um projeto **multitarget**, todo o código será avaliado se puder rodar corretamente tanto em netstandard2 quanto em net40. 

### BoletoNetCore.Pdf
Responsável pelos serviços de  impessão em PDF. 

Obs.: Para geração de PDF em linux (ambientes baseados em Debian), é necessário a instalação das seguintes dependências:

```bash
apt-get install -y libfontconfig1 libxrender1 libxext6
```

Também é necessário garantir a permissão de execução para o binário responsável por gerar o PDF:

```bash
chmod +x "<Caminho do projeto>/BoletoNetCore.Testes/bin/Debug/net7.0/Rotativa/Linux/wkhtmltopdf"
```

### BoletoNetCore.Testes
Validação e testes de toda a lógica dos boletos.

- Em linhas gerais, novas carteiras deverão passar por validações e apresentar comprovação de passe nos testes propostos, contendo validações conforme proposto acima.
- Procure comentar todo o código para facilitar o entendimento e motivação para outros colegas. Embora o código original não seja muito comentado, não é motivo para que se crie o hábito. 
- Se houver a necessidade de incluir novas imagens ou recursos para impressão, abra uma issue primeiro, ou apenas use as pastas convencionadas no projeto para receber esses tipos de arquivo. /Images e /BoletoBancario
- Nomenclaturas e termos devem estar alinhados aos padrões definidos no CNAB: <https://cmsportal.febraban.org.br/Arquivos/documentos/PDF/Layout%20padrao%20CNAB240%20%20V%2010%2005%20-%2005_11_18.pdf>
- A Estrutura das classes dos Banco estão distribuídas em arquivos que representam partial classes
- Cada uma das partial classes implementa uma interface diferente que representa um formato, existem 3 formatos implementados:
CNAB400, CNAB240 e OnlineRest (**Procuramos Implementadores**)

## Migrando do Boleto2Net
Este projeto possui algumas diferenças relevantes em relação ao Boleto2Net que podem quebrar o seu código:
- Retorno de Arquivos CNAB geram **CodMovimentoRetorno** no Lugar de **CodOcorrencia**.
- Se você quer usar a impressão em PDF, use o **BoletoNetCorePdfProxy** e não **BoletoNetCoreProxy**.
- Para a impressão em PDF, também é necessário a instalação do pacote [BoletoNetCore.Pdf](https://www.nuget.org/packages/BoletoNetCore.PDF/).
- Este projeto não usa **System.Web** então, não existem componentes manipuláveis para WebForms para o Editor do VS. 
- Cedente e Sacado foram substituidos em todo o projeto pelos termos atuais **Beneficiario** e **Pagador**