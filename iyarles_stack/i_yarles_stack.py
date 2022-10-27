from aws_cdk import (
    Stack,
    aws_apprunner_alpha as apprunner,
    aws_ecr_assets as ecr_assets,
)
from constructs import Construct
from os import environ


class IYarlesStack(Stack):

    def __init__(self, scope: Construct, construct_id: str, **kwargs) -> None:
        super().__init__(scope, construct_id, **kwargs)

        iyarles_image = ecr_assets.DockerImageAsset(
            self,
            "iyarles_image",
            directory="app"
        )

        iyarles_app = apprunner.Service(
            self,
            "iyarles",
            service_name="iyarles",
            source=apprunner.Source.from_asset(
                asset=iyarles_image,
                image_configuration=apprunner.ImageConfiguration(
                    port=80,
                    environment={
                        'GOOGLE_APP_PASSWORD': environ['GOOGLE_APP_PASSWORD'],
                        'IYARLES_ReCaptcha__ScoreThreshold': environ['IYARLES_ReCaptcha__ScoreThreshold'],
                        'IYARLES_ReCaptcha__SecretKey': environ['IYARLES_ReCaptcha__SecretKey'],
                        'IYARLES_ReCaptcha__SiteKey': environ['IYARLES_ReCaptcha__SiteKey'],
                        'IYARLES_ReCaptcha__UseRecaptchaNet': environ['IYARLES_ReCaptcha__UseRecaptchaNet'],
                        'IYARLES_ReCaptcha__Version': environ['IYARLES_ReCaptcha__Version']
                    }
                ),

            )
        )
