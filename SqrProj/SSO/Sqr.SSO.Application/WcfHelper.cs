using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.SSO.Application
{
    public static class WcfHelper
    {
        public static TReturn Using<TChannel, TReturn>(this System.ServiceModel.ClientBase<TChannel> client,Func<System.ServiceModel.ClientBase<TChannel>, TReturn> work) where TChannel : class
        {
            var result = default(TReturn);
            result = work(client);
            try
            {
                client.Close();
            }
            catch(Exception e)
            {
                client.Abort();
            }
            return result;
        }

        public static void Using<TChannel>(this System.ServiceModel.ClientBase<TChannel> client, Action<System.ServiceModel.ClientBase<TChannel>> work) where TChannel : class
        {
            work(client);
            try
            {
                client.Close();
            }
            catch (Exception e)
            {
                client.Abort();
            }
        }

        public static TReturn Using<TChannel, TReturn>(Func<TChannel, TReturn> func)
        {
            var chanFactory = new ChannelFactory<TChannel>("*");
            TChannel channel = chanFactory.CreateChannel();
            ((IClientChannel)channel).Open();
            TReturn result = func(channel);
            try
            {
                ((IClientChannel)channel).Close();
            }
            catch
            {
                ((IClientChannel)channel).Abort();
            }
            return result;
        }

        public static void Using<TChannel>(Action<TChannel> action)
        {
            var chanFactory = new ChannelFactory<TChannel>("*");
            TChannel channel = chanFactory.CreateChannel();
            ((IClientChannel)channel).Open();
            action(channel);
            try
            {
                ((IClientChannel)channel).Close();
            }
            catch
            {
                ((IClientChannel)channel).Abort();
            }
        }

    }
}
