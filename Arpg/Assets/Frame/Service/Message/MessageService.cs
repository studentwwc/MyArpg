using System;
using System.Collections.Generic;
using Frame;
using UnityEngine;

namespace Frame
{
    public struct HandleMessage
    {
        public MessageType MessageType;
        public Action<IMessage> handle;
    }

    public interface IMessageListener
    {
        public HandleMessage[] GetMessage();
    }

    public class MessageService:Service
    {
        public void Init()
        {
           App.AppInstance.RegisterService(this);
        }
        private Dictionary<MessageType, Action<IMessage>> _handleMessagesMap = new Dictionary<MessageType, Action<IMessage>>();

        public void RegisterMessages(IMessageListener messageListener)
        {
            
        }

        public void RegisterMessage(HandleMessage handleMessage)
        {
            if (_handleMessagesMap.ContainsKey(handleMessage.MessageType))
            {
                _handleMessagesMap[handleMessage.MessageType] += handleMessage.handle;
            }
            else
            {
                _handleMessagesMap.Add(handleMessage.MessageType,handleMessage.handle);
            }
        }
    }
}

