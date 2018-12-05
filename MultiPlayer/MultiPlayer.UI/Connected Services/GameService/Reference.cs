﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultiPlayer.UI.GameService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameService.IGameDataService")]
    public interface IGameDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/GetAllGames", ReplyAction="http://tempuri.org/IGameDataService/GetAllGamesResponse")]
        MultiPlayer.BusinessObjects.Models.Game[] GetAllGames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/GetAllGames", ReplyAction="http://tempuri.org/IGameDataService/GetAllGamesResponse")]
        System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game[]> GetAllGamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/CreateGame", ReplyAction="http://tempuri.org/IGameDataService/CreateGameResponse")]
        MultiPlayer.BusinessObjects.Models.Game CreateGame(MultiPlayer.BusinessObjects.Models.Game game);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/CreateGame", ReplyAction="http://tempuri.org/IGameDataService/CreateGameResponse")]
        System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> CreateGameAsync(MultiPlayer.BusinessObjects.Models.Game game);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/DeleteGame", ReplyAction="http://tempuri.org/IGameDataService/DeleteGameResponse")]
        MultiPlayer.BusinessObjects.Models.Game DeleteGame(MultiPlayer.BusinessObjects.Models.Game game);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/DeleteGame", ReplyAction="http://tempuri.org/IGameDataService/DeleteGameResponse")]
        System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> DeleteGameAsync(MultiPlayer.BusinessObjects.Models.Game game);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/GetGameById", ReplyAction="http://tempuri.org/IGameDataService/GetGameByIdResponse")]
        MultiPlayer.BusinessObjects.Models.Game GetGameById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/GetGameById", ReplyAction="http://tempuri.org/IGameDataService/GetGameByIdResponse")]
        System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> GetGameByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/UpdateGame", ReplyAction="http://tempuri.org/IGameDataService/UpdateGameResponse")]
        MultiPlayer.BusinessObjects.Models.Game UpdateGame(MultiPlayer.BusinessObjects.Models.Game game);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameDataService/UpdateGame", ReplyAction="http://tempuri.org/IGameDataService/UpdateGameResponse")]
        System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> UpdateGameAsync(MultiPlayer.BusinessObjects.Models.Game game);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameDataServiceChannel : MultiPlayer.UI.GameService.IGameDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameDataServiceClient : System.ServiceModel.ClientBase<MultiPlayer.UI.GameService.IGameDataService>, MultiPlayer.UI.GameService.IGameDataService {
        
        public GameDataServiceClient() {
        }
        
        public GameDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MultiPlayer.BusinessObjects.Models.Game[] GetAllGames() {
            return base.Channel.GetAllGames();
        }
        
        public System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game[]> GetAllGamesAsync() {
            return base.Channel.GetAllGamesAsync();
        }
        
        public MultiPlayer.BusinessObjects.Models.Game CreateGame(MultiPlayer.BusinessObjects.Models.Game game) {
            return base.Channel.CreateGame(game);
        }
        
        public System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> CreateGameAsync(MultiPlayer.BusinessObjects.Models.Game game) {
            return base.Channel.CreateGameAsync(game);
        }
        
        public MultiPlayer.BusinessObjects.Models.Game DeleteGame(MultiPlayer.BusinessObjects.Models.Game game) {
            return base.Channel.DeleteGame(game);
        }
        
        public System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> DeleteGameAsync(MultiPlayer.BusinessObjects.Models.Game game) {
            return base.Channel.DeleteGameAsync(game);
        }
        
        public MultiPlayer.BusinessObjects.Models.Game GetGameById(int id) {
            return base.Channel.GetGameById(id);
        }
        
        public System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> GetGameByIdAsync(int id) {
            return base.Channel.GetGameByIdAsync(id);
        }
        
        public MultiPlayer.BusinessObjects.Models.Game UpdateGame(MultiPlayer.BusinessObjects.Models.Game game) {
            return base.Channel.UpdateGame(game);
        }
        
        public System.Threading.Tasks.Task<MultiPlayer.BusinessObjects.Models.Game> UpdateGameAsync(MultiPlayer.BusinessObjects.Models.Game game) {
            return base.Channel.UpdateGameAsync(game);
        }
    }
}
