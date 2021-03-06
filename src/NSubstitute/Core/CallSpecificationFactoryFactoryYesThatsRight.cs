﻿using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
    public class CallSpecificationFactoryFactoryYesThatsRight
    {
        public static ICallSpecificationFactory CreateCallSpecFactory()
        {
            return
                new CallSpecificationFactory(
                    new ArgumentSpecificationsFactory(
                        new MixedArgumentSpecificationsFactory(
                            new ArgumentSpecificationFactory(
                                NewParamsArgumentSpecificationFactory(),
                                NewNonParamsArgumentSpecificationFactory()
                                ),
                            new SuppliedArgumentSpecificationsFactory(
                                new ArgumentSpecificationCompatibilityTester(
                                    new DefaultChecker(new DefaultForType())
                                    )
                                )
                            )
                        )
                    );
        }

        private static IParamsArgumentSpecificationFactory NewParamsArgumentSpecificationFactory()
        {
            return
                new ParamsArgumentSpecificationFactory(
                    new ArgumentEqualsSpecificationFactory(),
                    new ArrayArgumentSpecificationsFactory(
                        new NonParamsArgumentSpecificationFactory(new ArgumentEqualsSpecificationFactory())
                    ),
                    new ParameterInfosFromParamsArrayFactory(),
                    new ArrayContentsArgumentSpecificationFactory()
                );
        }

        private static INonParamsArgumentSpecificationFactory NewNonParamsArgumentSpecificationFactory()
        {
            return
                new NonParamsArgumentSpecificationFactory(new ArgumentEqualsSpecificationFactory()
                );
        }
    }
}