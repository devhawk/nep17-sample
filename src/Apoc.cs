using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using System;
using System.ComponentModel;
using System.Numerics;

namespace DevHawk.Contracts
{
    [DisplayName("DevHawk.Contracts.ApocToken")]
    [ManifestExtra("Author", "Harry Pierson")]
    [ManifestExtra("Email", "harrypierson@hotmail.com")]
    [ManifestExtra("Description", "This is a NEP17 example")]
    [SupportedStandards("NEP17", "NEP10")]
    public partial class ApocToken : SmartContract
    {
        #region Token Settings
        static readonly ulong MaxSupply = 10_000_000_000_000_000;
        static readonly ulong InitialSupply = 2_000_000_000_000_000;
        static readonly ulong TokensPerNEO = 1_000_000_000;
        static readonly ulong TokensPerGAS = 1;
        #endregion

        [InitialValue("NeDbSeaBiqnWVJ339aRxgwP7vHAzeo44gK", ContractParameterType.Hash160)]
        static readonly UInt160 Owner = default!;

        #region Notifications
        [DisplayName("Transfer")]
        public static event Action<UInt160, UInt160, BigInteger> OnTransfer = default!;
        #endregion

        // When this contract address is included in the transaction signature,
        // this method will be triggered as a VerificationTrigger to verify that the signature is correct.
        // For example, this method needs to be called when withdrawing token from the contract.
        public static bool Verify() => IsOwner();

        public static string Symbol() => "APOC";

        public static ulong Decimals() => 8;
    }
}
