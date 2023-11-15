﻿
namespace MyProjectBackend.Tests.AdditionalLogic.DummyObjects;

internal static class DummyStorage
{
   internal static string[] dummies = {
    "Capra ibex",
    "Leptoptilos crumeniferus",
    "Agelaius phoeniceus",
    "Macropus eugenii",
    "Bos frontalis",
    "Alopex lagopus",
    "Junonia genoveua",
    "Connochaetus taurinus",
    "Falco peregrinus",
    "Cereopsis novaehollandiae",
    "Bassariscus astutus",
    "Ursus arctos",
    "Stercorarius longicausus",
    "Macaca mulatta",
    "Spermophilus tridecemlineatus",
    "Macropus eugenii",
    "Uraeginthus angolensis",
    "Genetta genetta",
    "Butorides striatus",
    "Pelecans onocratalus",
    "Phalaropus lobatus",
    "unavailable",
    "Vulpes chama",
    "Sciurus vulgaris",
    "Ctenophorus ornatus",
    "Pycnonotus barbatus",
    "Crotaphytus collaris",
    "Corallus hortulanus cooki",
    "Merops bullockoides",
    "Corvus albicollis",
    "Lepilemur rufescens",
    "Castor fiber",
    "Geochelone elephantopus",
    "Graspus graspus",
    "Trichoglossus chlorolepidotus",
    "Physignathus cocincinus",
    "Macaca fuscata"
};

    internal static string GetRandomDummy() => dummies[Random.Shared.Next(0, dummies.Length - 1)];
}