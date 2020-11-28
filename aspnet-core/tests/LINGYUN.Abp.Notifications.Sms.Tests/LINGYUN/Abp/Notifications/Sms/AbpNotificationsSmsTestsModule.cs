using LINGYUN.Abp.Tests;
using Volo.Abp.Modularity;

namespace LINGYUN.Abp.Notifications.Sms
{
    [DependsOn(
        typeof(AbpNotificationsSmsModule),
        typeof(AbpNotificationsTestsModule),
        typeof(AbpTestsBaseModule))]
    public class AbpNotificationsSmsTestsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            // �ı�Ĭ������ǰ׺����
            PreConfigure<AbpNotificationsSmsOptions>(options =>
            {
                options.TemplateParamsPrefix = "[sms-override]";
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // �Զ������ݴ�������
            Configure<AbpNotificationOptions>(options =>
            {
                // ����֪ͨ���ر�׼����֪ͨ
                options.NotificationDataMappings
                    .Mapping(
                        SmsNotificationPublishProvider.ProviderName,
                        NotificationsTestsNames.Test2,
                        data => NotificationData.ToStandardData(data));

                // ����֪ͨ�����κδ���
                options.NotificationDataMappings
                    .Mapping(
                        SmsNotificationPublishProvider.ProviderName,
                        NotificationsTestsNames.Test3,
                        data => data);
            });
        }
    }
}