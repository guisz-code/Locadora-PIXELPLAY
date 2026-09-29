// O usuário define a quantidade máxima de clientes
Console.Write("Digite o número máximo de clientes: ");
int maxClientes = int.Parse(Console.ReadLine());

// listas para cadastro de clientes
List<string> nomes = new List<string>();
List<string> cpfs = new List<string>();
List<string> telefones = new List<string>();
List<string> emails = new List<string>();

void CadastroCliente()
{
    // Coletar e validar NOMES
    if (nomes.Count >= maxClientes)
    {
        Console.WriteLine("Limite máximo de clientes atingido!");
        Console.ReadKey(); // Para aqui, e retorna depois que o usuário aperta uma tecla
        return;
    }

    Console.Clear();
    Console.WriteLine("====== CADASTRO DO CLIENTE ======");

    string nome;

    do
    {
        Console.Write("Nome completo: ");
        nome = Console.ReadLine().Trim();

        if (nome == "")// Verifica se a string é vazia
        {
            Console.WriteLine("Nome não pode ser vazio! Tente novamente.");
        }
    } while (nome == "");

    // Coleta o CPF do usuário
    string cpf;
    bool cpfValido;

    do
    {
        Console.Write("CPF (11 dígitos): ");
        cpf = Console.ReadLine().Trim();

        cpfValido = true; // começa assumindo que está válido

        // Verifica se tem exatamente 11 números
        if (cpf.Length != 11)
            cpfValido = false;

        // Verifica se todos os caracteres são números
        for (int i = 0; i < cpf.Length && cpfValido; i++)
        {
            // Se achar um caractere que não é número, o CPF é inválido
            if (cpf[i] < '0' || cpf[i] > '9')
                cpfValido = false;
        }

        // Caso esteja errado, mostra mensagem
        if (!cpfValido)
            Console.WriteLine("CPF inválido! Digite exatamente 11 números.");

    } while (!cpfValido); // repete até digitar certo

    // Coleta o telefone do usuário
    string telefone;
    bool telValido;

    do
    {
        Console.Write("TELEFONE (DDD + 9 + número = 11 dígitos): ");
        telefone = Console.ReadLine().Trim();

        telValido = true; // começa assumindo que está válido

        // Verifica se tem exatamente 11 números
        if (telefone.Length != 11)
            telValido = false;

        // Verifica se todos são números
        for (int i = 0; i < telefone.Length && telValido; i++)
        {
            // Se tiver algo que não seja número, invalida
            if (telefone[i] < '0' || telefone[i] > '9')
                telValido = false;
        }

        // Verifica se o número realmente é celular, começando com 9
        if (telValido && telefone[2] != '9')
            telValido = false;

        // Mensagem se estiver errado
        if (!telValido)
            Console.WriteLine("Telefone inválido! Deve ter 11 números e começar com DDD + 9.");

    } while (!telValido); // repete até digitar certo

    //coletar EMAIL
    // Coleta o email do usuário
    string email;
    bool emailValido;

    do
    {
        Console.Write("EMAIL (ex: nome@dominio.com): ");
        email = Console.ReadLine().Trim();

        emailValido = true; // começa assumindo que está válido

        // Posição do @ no texto
        int posArroba = email.IndexOf('@');

        // Última posição do @ (para ver se tem mais de um)
        int posUltimoArroba = email.LastIndexOf('@');

        // Posição do ponto depois do @
        int posPonto = (posArroba != -1) ? email.IndexOf('.', posArroba) : -1;

        // Aqui verificamos tudo que pode estar errado
        if (email == ""                     // não pode estar vazio
            || posArroba <= 0              // @ não pode ser o primeiro caractere
            || posArroba != posUltimoArroba // só pode ter 1 arroba
            || posPonto <= posArroba       // precisa ter ponto depois do arroba
            || posPonto == email.Length - 1) // ponto não pode ser o último caractere
        {
            emailValido = false;
            Console.WriteLine("EMAIL inválido! Use o formato nome@dominio.com");
        }

    } while (!emailValido); // repete até digitar certo

    //Adicionar as listas
    nomes.Add(nome);
    cpfs.Add(cpf);
    telefones.Add(telefone);
    emails.Add(email);

    Console.WriteLine("Usuário cadastrado com sucesso!");
    Console.ReadKey();

}

// LISTAS DE ITENS
List<int> codigosItem = new List<int>();      // Código automático
List<string> titulosItem = new List<string>(); // Nome do item
List<string> tiposItem = new List<string>();   // Filme ou Jogo
List<string> generosItem = new List<string>(); // Ação, Comédia, etc.
List<double> diariaItem = new List<double>();  // Valor da diária
List<string> statusItem = new List<string>();  // Disponível / Alugado

// CADASTROS DE ITENS

void CadastroItem()
{
    Console.Clear();
    Console.WriteLine("====== CADASTRO DE ITEM ======");

    // ---- TÍTULO DO ITEM ----
    string titulo;

    // Aqui repetimos até o usuário digitar um título válido
    do
    {
        Console.Write("Título do item: ");
        titulo = Console.ReadLine().Trim();

        if (titulo == "")
        {
            Console.WriteLine("O título não pode ficar vazio.");
        }

    } while (titulo == "");

    // ---- TIPO DO ITEM (Filme ou Jogo) ----
    string tipo = "";
    int escolhaTipo = 0;

    // Menu simples para escolher o tipo
    do
    {
        Console.WriteLine("Tipo do item:");
        Console.WriteLine("1 - Filme");
        Console.WriteLine("2 - Jogo");
        Console.Write("Escolha: ");

        int.TryParse(Console.ReadLine(), out escolhaTipo);

        if (escolhaTipo == 1)
            tipo = "Filme";
        else if (escolhaTipo == 2)
            tipo = "Jogo";
        else
            Console.WriteLine("Opção inválida! Escolha 1 ou 2.");

    } while (tipo == "");

    // ---- GÊNERO ----
    Console.Write("Gênero (Ação, Terror, Comédia, etc.): ");
    string genero = Console.ReadLine().Trim();


    // ---- VALOR DA DIÁRIA ----
    double diaria = -1;

    // Repetimos até digitar um valor positivo
    do
    {
        Console.Write("Valor da diária (R$): ");

        double.TryParse(Console.ReadLine(), out diaria);

        if (diaria <= 0)
        {
            Console.WriteLine("O valor deve ser maior que zero.");
        }

    } while (diaria <= 0);

    // ---- CÓDIGO AUTOMÁTICO ----
    int codigo = codigosItem.Count + 1; // usa a quantidade atual como código

    // ---- STATUS ----
    string status = "Disponível"; // Sempre começa disponível

    // ---- ARMAZENAR NAS LISTAS ----
    codigosItem.Add(codigo);
    titulosItem.Add(titulo);
    tiposItem.Add(tipo);
    generosItem.Add(genero);
    diariaItem.Add(diaria);
    statusItem.Add(status);

    Console.WriteLine("Item cadastrado com sucesso!");
    Console.WriteLine("Código do item: " + codigo);
    Console.ReadKey();
}

// LISTAS PARA REGISTRO DE LOCAÇÕES
List<string> cpfLocacoes = new List<string>();
List<int> codigoItemLocacoes = new List<int>();
List<DateTime> dataLocacoes = new List<DateTime>();
List<int> diasLocacoes = new List<int>();
List<double> valorTotalLocacoes = new List<double>();

void RealizarLocacao()
{
    Console.Clear();
    Console.WriteLine("====== REALIZAR LOCAÇÃO ======");

    // Pede e verifica o CPF
    string cpfConsta;

    do
    {
        Console.Write("CPF do cliente: ");
        cpfConsta = Console.ReadLine().Trim();

        if (!cpfs.Contains(cpfConsta)) // Confere se o CPF está na lista
        {
            Console.WriteLine("CPF não consta no sistema!");
        }

    } while (!cpfs.Contains(cpfConsta)); // Repete enquanto CPF não for encontrado

    // Mostra qual cliente está vinculado ao CPF digitado
    int indiceCliente = cpfs.IndexOf(cpfConsta);
    Console.WriteLine($"Cliente localizado: {nomes[indiceCliente]}");
    Console.WriteLine();

    // Pede e verifica o código do item
    int codigoConsta;
    int indiceItem;
    bool itemDisponivel;

    do
    {
        Console.Write("Código do item: ");

        // Tratamento de erro para entrada não numérica
        if (!int.TryParse(Console.ReadLine(), out codigoConsta))
        {
            Console.WriteLine("Digite um código válido!");
            itemDisponivel = false;
            continue;
        }

        // Verifica se o código existe
        if (!codigosItem.Contains(codigoConsta))
        {
            Console.WriteLine("Código do item inválido!");
            itemDisponivel = false;
            continue;
        }

        // Encontra o item na list 
        indiceItem = codigosItem.IndexOf(codigoConsta);

        // Verifica se o item está disponível
        if (statusItem[indiceItem] != "Disponível")
        {
            Console.WriteLine("Item não está disponível para locação!");
            itemDisponivel = false;
        }
        else
        {
            itemDisponivel = true;
        }

    } while (!codigosItem.Contains(codigoConsta) || !itemDisponivel);


    // Descobre onde o item está na lista
    indiceItem = codigosItem.IndexOf(codigoConsta);

    // Se não achar o item, dá erro e volta
    if (indiceItem == -1)
    {
        Console.WriteLine("Erro: item não encontrado!");
        Console.ReadKey();
        return;
    }

    // Mostra as informações do item escolhido
    Console.WriteLine("====== INFORMAÇÕES DO ITEM ======");
    Console.WriteLine("Título: " + titulosItem[indiceItem]);
    Console.WriteLine("Tipo: " + tiposItem[indiceItem]);
    Console.WriteLine("Gênero: " + generosItem[indiceItem]);
    Console.WriteLine("Diária: R$ " + diariaItem[indiceItem]);


    // Pede a quantidade de dias
    int diasLocacao;
    do
    {
        Console.WriteLine("Quantidade de dias de locação: ");

        if (!int.TryParse(Console.ReadLine(), out diasLocacao) || diasLocacao <= 0)
        {
            Console.WriteLine("Digite um número válido de dias (maior que zero)!");
        }
    } while (diasLocacao <= 0);

    // Calcula o valor total
    double valorTotal = diariaItem[indiceItem] * diasLocacao;
    DateTime dataLocacao = DateTime.Now;

    // Mostra resumo da locação
    Console.WriteLine("====== RESUMO DA LOCAÇÃO ======");
    Console.WriteLine($"Cliente: {nomes[indiceCliente]}");
    Console.WriteLine($"Item: {titulosItem[indiceItem]}");
    Console.WriteLine($"Data da locação: {dataLocacao:dd/MM/yyyy HH:mm}");
    Console.WriteLine($"Dias alugados: {diasLocacao}");
    Console.WriteLine($"Valor da diária: {diariaItem[indiceItem]:C}");
    Console.WriteLine($"Valor total: {valorTotal:C}");

    // Confirmação da locação
    Console.Write("Confirmar locação? (S/N): ");
    string confirmacao = Console.ReadLine().Trim().ToUpper();

    if (confirmacao == "S")
    {
        // Atualiza status do item para "Alugado"
        statusItem[indiceItem] = "Alugado";

        // Registra a locação
        cpfLocacoes.Add(cpfConsta);
        codigoItemLocacoes.Add(codigoConsta);
        dataLocacoes.Add(dataLocacao);
        diasLocacoes.Add(diasLocacao);
        valorTotalLocacoes.Add(valorTotal);

        Console.WriteLine("Locação realizada com sucesso!");
        Console.WriteLine($"Código da locação: {cpfLocacoes.Count}");
    }
    else
    {
        Console.WriteLine("Locação cancelada.");
    }

}

void RegistrarDevolucao()
{
    Console.Clear();
    Console.WriteLine("====== REGISTRAR DEVOLUÇÃO ======");

    // pedir CPF
    Console.Write("Digite o CPF do cliente: ");
    string cpfBusca = Console.ReadLine().Trim();

    // verificar se CPF existe
    if (!cpfs.Contains(cpfBusca))
    {
        Console.WriteLine("CPF não encontrado!");
        Console.ReadKey();
        return;
    }

    // mostrar locações desse CPF
    Console.WriteLine("\nLocações desse cliente:");
    bool achou = false;

    for (int i = 0; i < cpfLocacoes.Count; i++)
    {
        if (cpfLocacoes[i] == cpfBusca)
        {
            int codItem = codigoItemLocacoes[i];
            int idxItem = codigosItem.IndexOf(codItem);

            Console.WriteLine($"ID Locação: {i} | Item: {titulosItem[idxItem]} | Código: {codItem}");
            achou = true;
        }
    }

    // se o CPF não tiver locações
    if (!achou)
    {
        Console.WriteLine("Esse cliente não tem locações.");
        Console.ReadKey();
        return;
    }

    // escolher qual locação devolver
    Console.Write("\nDigite o ID da locação: ");
    int idLoc;

    if (!int.TryParse(Console.ReadLine(), out idLoc) ||
        idLoc < 0 || idLoc >= cpfLocacoes.Count ||
        cpfLocacoes[idLoc] != cpfBusca)
    {
        Console.WriteLine("ID inválido!");
        Console.ReadKey();
        return;
    }

    // pegar os dados da locação
    int codigoItem = codigoItemLocacoes[idLoc];
    int indiceItem = codigosItem.IndexOf(codigoItem);

    DateTime dataLocacao = dataLocacoes[idLoc];
    int diasContratados = diasLocacoes[idLoc];
    double valorOriginal = valorTotalLocacoes[idLoc];

    // pedir a data da devolução
    Console.Write("Digite a data da devolução (DD/MM/AAAA): ");
    DateTime dataDevolucao;

    if (!DateTime.TryParse(Console.ReadLine(), out dataDevolucao))
    {
        Console.WriteLine("Data inválida!");
        Console.ReadKey();
        return;
    }

    // calcular dias usados
    int diasUsados = (dataDevolucao.Date - dataLocacao.Date).Days;
    if (diasUsados < 0) diasUsados = 0;

    // calcular atraso
    int atraso = diasUsados - diasContratados;
    if (atraso < 0) atraso = 0;

    // multa = R$2 por dia
    double multa = atraso * 2.0;

    // valor final
    double valorFinal = valorOriginal + multa;

    // deixar item disponível de novo
    statusItem[indiceItem] = "Disponível";

    // mostrar resumo
    Console.WriteLine("\n====== RESUMO ======");
    Console.WriteLine($"Item: {titulosItem[indiceItem]}");
    Console.WriteLine($"Dias contratados: {diasContratados}");
    Console.WriteLine($"Dias usados: {diasUsados}");
    Console.WriteLine($"Atraso: {atraso} dia(s)");
    Console.WriteLine($"Valor original: R$ {valorOriginal:F2}");
    Console.WriteLine($"Multa: R$ {multa:F2}");
    Console.WriteLine($"Valor final: R$ {valorFinal:F2}");

    Console.ReadKey();
}

void MostrarRelatorios()
{
    Console.Clear();
    Console.WriteLine("====== RELATÓRIOS GERAIS ======");
    Console.WriteLine("1 - Itens cadastrados");
    Console.WriteLine("2 - Clientes cadastrados");
    Console.WriteLine("3 - Locações ativas");
    Console.WriteLine("4 - Relatório financeiro");
    Console.WriteLine("0 - Voltar");
    Console.Write("Escolha: ");

    int op;
    int.TryParse(Console.ReadLine(), out op);

    Console.Clear();

    switch (op)
    {
        case 1:
            // Mostra todos os itens que existem no sistema
            Console.WriteLine("===== ITENS CADASTRADOS =====");

            for (int i = 0; i < codigosItem.Count; i++)
            {
                Console.WriteLine($"Código: {codigosItem[i]}");
                Console.WriteLine($"Título: {titulosItem[i]}");
                Console.WriteLine($"Tipo: {tiposItem[i]}");
                Console.WriteLine($"Gênero: {generosItem[i]}");
                Console.WriteLine($"Diária: R$ {diariaItem[i]:F2}");
                Console.WriteLine($"Status: {statusItem[i]}");
                Console.WriteLine("------------------------");
            }

            Console.ReadKey();
            break;

        case 2:
            // Mostra todos os clientes cadastrados
            Console.WriteLine("===== CLIENTES CADASTRADOS =====");

            for (int i = 0; i < nomes.Count; i++)
            {
                Console.WriteLine($"Nome: {nomes[i]}");
                Console.WriteLine($"CPF: {cpfs[i]}");
                Console.WriteLine($"Telefone: {telefones[i]}");
                Console.WriteLine($"Email: {emails[i]}");
                Console.WriteLine("------------------------");
            }

            Console.ReadKey();
            break;

        case 3:
            // Mostra itens que estão alugados e ainda não foram devolvidos
            Console.WriteLine("===== LOCAÇÕES ATIVAS =====");

            bool tem = false;

            for (int i = 0; i < cpfLocacoes.Count; i++)
            {
                int cod = codigoItemLocacoes[i];
                int idx = codigosItem.IndexOf(cod);

                if (statusItem[idx] == "Alugado")
                {
                    tem = true;

                    Console.WriteLine($"Cliente (CPF): {cpfLocacoes[i]}");
                    Console.WriteLine($"Item: {titulosItem[idx]}");
                    Console.WriteLine($"Código: {cod}");
                    Console.WriteLine($"Data da locação: {dataLocacoes[i]:dd/MM/yyyy}");
                    Console.WriteLine($"Dias: {diasLocacoes[i]}");
                    Console.WriteLine("------------------------");
                }
            }

            if (!tem)
                Console.WriteLine("Nenhuma locação ativa.");

            Console.ReadKey();
            break;

        case 4:
            // Mostra quanto dinheiro o sistema ganhou nas locações
            Console.WriteLine("===== RELATÓRIO FINANCEIRO =====");

            double total = 0;

            for (int i = 0; i < valorTotalLocacoes.Count; i++)
            {
                total += valorTotalLocacoes[i]; // soma tudo
            }

            Console.WriteLine($"Total arrecadado: R$ {total:F2}");
            Console.WriteLine($"Total de locações: {valorTotalLocacoes.Count}");
            Console.ReadKey();
            break;

        case 0:
            // Volta ao menu
            return;

        default:
            // Caso digite número errado
            Console.WriteLine("Opção inválida!");
            Console.ReadKey();
            break;
    }
}

int MostrarMenu()
{
    Console.Clear();// Limpa antes de mostrar o menu
    Console.WriteLine("======= LOCADORA PIXELPLAY ======");
    Console.WriteLine("1 - Cadastro de Cliente");
    Console.WriteLine("2 - Cadastro de Itens");
    Console.WriteLine("3 - Realizar Locação");
    Console.WriteLine("4 - Realizar Devolução");
    Console.WriteLine("5 - Relatótios Gerais");
    Console.WriteLine("0 - Sair");

    int opcao = int.Parse(Console.ReadLine());
    return opcao;
}

int opcao;

do
{
    opcao = MostrarMenu();

    switch (opcao)
    {
        case 1:
            CadastroCliente();
            break;

        case 2:
            CadastroItem();
            break;

        case 3:
            RealizarLocacao();
            break;

        case 4:
            RegistrarDevolucao();
            break;

        case 5:
            MostrarRelatorios();
            break;

    }
} while (opcao != 0);


