using System;
using NetDevPack.Domain;

namespace NCwDDD.Domain.Models
{
	public class Category : Entity, IAggregateRoot
    {
        protected Category() { }

        public Category(Guid id, string name, CategoryType categoryType)
        {
            Id = id;
            Name = name;
            CategoryType = categoryType;
        }

		public string Name { get; private set; }

        public CategoryType CategoryType { get; private set; }

        public Product Product { get; set; }
    }

    public enum CategoryType
    {
        AcessoriosParaVeiculos = 0,
        Agro = 1,
        AlimentosEBebidas = 2,
        Animais = 3,
        AntiguidadesEColecoes = 4,
        ArtePapelariaArmarinho = 5,
        Bebes = 6,
        BelezaECuidadoPessoal = 7,
        BrinquedosEHobbies = 8,
        CalçadosRoupasEBolsas = 9,
        CamerasEAcessorios = 10,
        CarrosMotosOutros = 11,
        CasaMoveisDecoracao = 12,
        CelularesETelefones = 13,
        Construcao = 14,
        Eletrodomesticos = 15,
        EletronicosAudioEVideo = 16,
        Informatica = 17,
        Outros = 18
    }
}

