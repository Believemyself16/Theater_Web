<template>
  <v-container>
    <v-form>
      <v-row>
        <v-col cols="6">
          <!-- outlined để có viền ngoài -->
          <v-text-field
            label="* Họ tên"
            prepend-inner-icon="mdi-account"
            outlined
            dense
          ></v-text-field>
        </v-col>
        <v-col cols="6">
          <v-text-field
            type="email"
            label="* Email"
            prepend-inner-icon="mdi-email"
            outlined
            dense
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="6">
          <v-text-field
            type="input"
            label="* Tên đăng nhập"
            prepend-inner-icon="mdi-account"
            outlined
            dense
          ></v-text-field>
        </v-col>
        <v-col cols="6">
          <v-text-field
            type="input"
            label="* Số điện thoại"
            prepend-inner-icon="mdi-phone"
            outlined
            dense
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="6">
          <v-text-field
            type="password"
            label="* Mật khẩu"
            prepend-inner-icon="mdi-lock"
            outlined
            dense
          ></v-text-field>
        </v-col>
        <!-- <v-col cols="6">
          <v-text-field
            type="password"
            label="* Xác nhận lại mật khẩu"
            prepend-inner-icon="mdi-lock"
            outlined
            dense
          ></v-text-field>
        </v-col> -->
      </v-row>
      <!-- <v-row>
        <v-col cols="6">
          <v-text-field
            type="date"
            label="* Ngày sinh"
            prepend-inner-icon="mdi-calendar"
            outlined
            dense
          ></v-text-field>
        </v-col>
        <v-col cols="6">
          <v-select
            label="* Giới tính"
            :items="['Nam', 'Nữ', 'Khác']"
            prepend-inner-icon="mdi-human"
            outlined
            dense
          ></v-select>
        </v-col>
      </v-row> -->
      <!-- <v-row>
        <v-col cols="6">Captcha</v-col>
        <v-col cols="6">
          <v-text-field
            type="input"
            placeholder="Mã xác thực"
            outlined
            dense
          ></v-text-field>
        </v-col>
      </v-row> -->
      <v-row>
        <v-checkbox v-model="checkboxValue"></v-checkbox>
        <!-- hiển thị pop-up -->
        <v-dialog width="800" v-model="privacyPolicy">
          <ChinhSachBaoMat />
        </v-dialog>
        <v-dialog width="800" v-model="terms">
          <DieuKhoanSuDung />
        </v-dialog>
        <!-- phần checkbox -->
        <span class="my-auto">
          Tôi cam kết tuân theo
          <a href="" @click.prevent="showPrivacyPolicy">chính sách bảo mật</a>
          và
          <a href="" @click.prevent="showTerms">điều khoản sử dụng</a> của
          BetaCinemas.
        </span>
      </v-row>
    </v-form>
  </v-container>
</template>

<script>
import axios from "axios";
import ChinhSachBaoMat from "@/components/TermsAndPolicies/ChinhSachBaoMat.vue";
import DieuKhoanSuDung from "@/components/TermsAndPolicies/DieuKhoanSuDung.vue";
export default {
  name: "DangKi",
  components: {
    ChinhSachBaoMat,
    DieuKhoanSuDung,
  },
  data() {
    return {
      checkboxValue: false,
      privacyPolicy: false,
      terms: false,
    };
  },
  methods: {
    showPrivacyPolicy() {
      this.privacyPolicy = true;
    },
    showTerms() {
      this.terms = true;
    },
  },
};
</script>

<style scoped>
a {
  text-decoration: none;
}
a:hover {
  text-decoration: underline;
}
</style>
