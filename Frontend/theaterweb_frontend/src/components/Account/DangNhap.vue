<template>
  <v-container>
    <v-form>
      <v-row>
        <v-col cols="12">
          <v-text-field
            label="Email"
            type="email"
            prepend-inner-icon="mdi-account"
            outlined
            dense
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
          <v-text-field
            label="Mật khẩu"
            prepend-inner-icon="mdi-lock"
            outlined
            dense
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
          <v-dialog width="800" v-model="forgotPassword">
            <QuenMatKhau />
          </v-dialog>
          <!-- thẻ span sẽ hiển thị các thẻ con -->
          <span>
            <a href="" @click.prevent="showForgotPassword">Quên mật khẩu?</a>
          </span>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>

<script>
import QuenMatKhau from "@/components/Account/QuenMatKhau.vue";
export default {
  name: "DangNhap",
  components: {
    QuenMatKhau,
  },
  data() {
    return {
      forgotPassword: false,
    };
  },
  methods: {
    showForgotPassword() {
      this.forgotPassword = true;
    },
  },
};
</script>
